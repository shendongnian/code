    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private int[,] imgArr = new int[1360, 1024];  //the 2D source from the camera
            private int[,] rotArr = new int[1360, 1024];  //the rotated output
            Bitmap drawImg = new Bitmap(1360, 1024);      
            private float angle = 0;
    
            public Form1()
            {
                InitializeComponent();
                //Make an RGB stripe for testing
                for (int i = 0; i < 1360; i++)
                {
                    for (int j = 0; j < 1024; j++)
                    {
                        if (j < 333)
                        {
                            imgArr[i, j] = -65536; //0xFFFF0000 - red
                        }
                        else if (j < 666)
                        {
                            imgArr[i, j] = -16711936; //0xFF00FF00 - green
                        }
                        else
                        {
                            imgArr[i, j] = -16776961; //0xFF0000FF - blue
                        }                       
                    }
                }          
               
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                // Copy array to a bitmap - fast!
                unsafe
                {
                    fixed (int* intPtr = &imgArr[0, 0])
                    {
                        drawImg = new Bitmap(1024, 1360, 4096, PixelFormat.Format32bppArgb, new IntPtr(intPtr));
                        //rotate because of the row layout of [,] array
                        drawImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                }
                          
                // transform 
                GraphicsPath gp = new GraphicsPath();
                gp.AddPolygon(new Point[]{new Point(0,0), 
                              new Point(drawImg.Width,0), 
                              new Point(0,drawImg.Height)});
                Matrix m = new Matrix();
                m.RotateAt(angle, new PointF((float)drawImg.Width/2, (float)drawImg.Height/2)); 
                gp.Transform(m);
                PointF[] pts = gp.PathPoints;
    
                //draw rotated image
                Bitmap rotImg = new Bitmap(1360, 1024);
                Graphics g = Graphics.FromImage(rotImg);
                // for speed...
                //g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(drawImg, pts);
               
                //rotate again to get [,] array layout
                //and copy array data out 
                rotImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
                BitmapData bData = rotImg.LockBits(
                                            new Rectangle(new Point(), rotImg.Size),
                                            ImageLockMode.ReadOnly,
                                            PixelFormat.Format32bppArgb);
                int byteCount = bData.Stride * (rotImg.Height);
                int[] flatArr = new int[byteCount / 4];
                //Do this in two steps - first to a flat array, then 
                //block copy to the [,] array
                Marshal.Copy(bData.Scan0, flatArr, 0, byteCount / 4);
                Buffer.BlockCopy(flatArr, 0, rotArr, 0, byteCount);
    
                // unlock the bitmap!!
                rotImg.UnlockBits(bData); 
     
                // for show... draw the rotated image to the picturebox
                rotImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                e.Graphics.DrawImage(rotImg, new Point(0, 0));
    
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                // increment angle and paint
                angle += 1.0f;
                if (angle > 360.0f) { angle = 0; }
                pictureBox1.Invalidate();
            }
    
        }
     }
