    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        Bitmap test = new Bitmap(512, 512, PixelFormat.Format24bppRgb);
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 0; numericUpDown1.Maximum = 255;
        }
        unsafe public static Bitmap LockBits(Bitmap bmp, int tolerancenumeric)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* ptr = (byte*)bmpData.Scan0;
            int numBytes = bmpData.Stride * bmp.Height;
            for (int counter = 0; counter < numBytes; counter += 6)
                *(ptr + counter) = (byte)tolerancenumeric;
            bmp.UnlockBits(bmpData);
            return bmp;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = LockBits(test, (int)numericUpDown1.Value);
        }
    }
    }
