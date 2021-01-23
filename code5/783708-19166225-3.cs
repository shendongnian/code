    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    namespace testScreenCapScale
    {
        public partial class Form1 : Form
        {
            public Form1() { InitializeComponent(); }
            private void button1_Click(object sender, EventArgs e)
            {
                CaptureScreen();
                printDocument1.Print();
            }
            private Bitmap _memoryImage;
            private void CaptureScreen()
            {
                // put into using construct because Graphics objects do not 
                //  get automatically disposed when leaving method scope
                using (var myGraphics = CreateGraphics())
                {
                    var s = Size;
                    _memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
                    using (var memoryGraphics = Graphics.FromImage(_memoryImage))
                    {
                        memoryGraphics.CopyFromScreen(Location.X, Location.Y, 0, 0, s);
                    }
                }
            }
            private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
            {
                // calculate width and height scalings taking page margins into account
                var wScale = e.MarginBounds.Width / (float)_memoryImage.Width;
                var hScale = e.MarginBounds.Height / (float)_memoryImage.Height;
                // choose the smaller of the two scales
                var scale = wScale < hScale ? wScale : hScale;
                // apply scaling to the image
                e.Graphics.ScaleTransform(scale, scale);
                // print to default printer's page
                e.Graphics.DrawImage(_memoryImage, 0, 0);
            }
        }
    }
