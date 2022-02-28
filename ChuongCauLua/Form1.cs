using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongCauLua
{
    public partial class Form1 : Form
    {
        private Bitmap lua, NhanVat;
        private Graphics graphicform;
        private int x, y, fcol, frow, sttlua, xnhanvat, ynhanvat, stt;
        private Keys KEY;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.D)
            {
                KEY = Keys.D;
                walktime.Start();

            }
            if (e.KeyCode == Keys.A)
            {
                KEY = Keys.A;
                walktime.Start();

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {

                walktime.Stop();

            }
            if (e.KeyCode == Keys.A)
            {

                walktime.Stop();

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void walktime_Tick(object sender, EventArgs e)
        {
           if(KEY==Keys.D)
            {
               if(stt==5)
                {
                    stt = 6;
                }
               else
                {
                    stt = 5;
                }
                xnhanvat += 20;

            }
           if (KEY == Keys.A)
           {
                if (stt == 2)
                {
                    stt = 0;
                }
                else
                {
                    stt = 2;
                }
                xnhanvat -= 20;
           }
            Refresh();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           
            x = xnhanvat + 80;
            y = ynhanvat + 20;
            if (KEY == Keys.D)
            {
                x = xnhanvat + 80;
                
            }
            if (KEY == Keys.A)
            {
                x = xnhanvat - 60;
                
            }
            TimeLua.Start();

        }

        private Bitmap spritewalk;
        private Bitmap spritequacaulua;

        private void Form1_Load(object sender, EventArgs e)
        {
            xnhanvat = 90;
            ynhanvat = 175;
            
            sttlua = 0;
            stt = 0;

            spritewalk = new Bitmap(Properties.Resources.sonicvip, new Size(273, 252));
            spritequacaulua = new Bitmap(Properties.Resources.Lua, new Size(560, 280));



        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void TimeLua_Tick(object sender, EventArgs e)
        {
            
            
           
            if(sttlua>32)
            {
                sttlua = -1;
                TimeLua.Stop();
            }
            sttlua++;
            fcol = sttlua % 8;
            frow = sttlua / 8;
            if (KEY == Keys.D)
            {
                x += 4;
            }

            if (KEY == Keys.A)
            {
                x -= 4;
            }
            Refresh();
            
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphicform = e.Graphics;
            
            

            NhanVat = new Bitmap(50, 120);
            Graphics charac = Graphics.FromImage(NhanVat);
            charac.DrawImage(spritewalk, 0, 0, new Rectangle((stt % 5) * 50, (stt / 5) * 120, 50, 120), GraphicsUnit.Pixel);
            graphicform.DrawImageUnscaled(NhanVat, xnhanvat, ynhanvat);
            charac.Dispose();



            
            lua = new Bitmap(70, 70);
            Graphics g = Graphics.FromImage(lua);
            g.DrawImage(spritequacaulua, 0, 0, new Rectangle(fcol * 70, frow * 70, 70, 70), GraphicsUnit.Pixel);
            graphicform.DrawImageUnscaled(lua, x, y);
            g.Dispose();

        }
    }
}
