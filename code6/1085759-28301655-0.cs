    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace ScreenOutput
    {
        public partial class Form1 : Form
        {
        private Bitmap myBitmap = new Bitmap(@".\screenshot.jpg");
        private PictureBox screenshot;
        private int Xcount;
        private int maxXValue = 1919;
        private int maxYValue = 1079;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            screenshot.Load(@".\screenshot.jpg");
            screenshot.Image = myBitmap;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Random random = new Random();
            for (Xcount = 0; Xcount < maxXValue; Xcount++)
            {
                screenshot.Invalidate();
                screenshot.Update();
                for (int Ycount = 0; Ycount < maxYValue; Ycount++)
                {
                    int calculatedX = Xcount + random.Next(0, maxXValue);
                    if (calculatedX > maxXValue) calculatedX = maxXValue;
                    myBitmap.SetPixel(Xcount, Ycount, myBitmap.GetPixel(calculatedX, Ycount));
                }
            }
        }
    }
    }
