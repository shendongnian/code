    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace testImageBlender
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            Bitmap imBase;
            Bitmap imMask,imMask2;
            Bitmap blendedImage;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        imBase = new Bitmap(openFileDialog1.FileName);
                        imMask = new Bitmap(openFileDialog2.FileName);
                        blendedImage = new Bitmap(openFileDialog2.FileName);
                        blendImage();
                    }
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (imBase != null)
                {
                    if (imMask != null)
                    {
                        if (blendedImage != null)
                        {
                            e.Graphics.DrawImage(blendedImage, e.ClipRectangle);
                        }
                    }
                }
            }
    
            private void blendImage()
            {
                Rectangle mRec = new Rectangle(0, 0, imMask.Width, imMask.Height);
                float intensity = 0;
                //playing around with images to get pixel format 24bpp RGB, most probably a very bad way of doing it, but I don't know enough about image format and lockbits to do it nice and clean yet
                imMask2 = new Bitmap(imMask);
                
                Graphics.FromImage(imBase).DrawImage(imBase, 0, 0, imMask.Width, imMask.Height);
                Graphics.FromImage(blendedImage).DrawImage(imMask, 0, 0, imMask.Width, imMask.Height);
                Graphics.FromImage(imMask2).DrawImage(imMask, 0, 0, imMask.Width, imMask.Height);
    
                BitmapData imageData = imBase.LockBits(mRec, ImageLockMode.ReadOnly, imBase.PixelFormat);
                BitmapData maskData = imMask2.LockBits(mRec, ImageLockMode.ReadOnly, imMask.PixelFormat);
                BitmapData blendedData = blendedImage.LockBits(mRec, ImageLockMode.WriteOnly, blendedImage.PixelFormat);
    
                unsafe
                {
    
                    byte* imagePointer = (byte*)imageData.Scan0;
                    byte* maskPointer = (byte*)maskData.Scan0;
                    byte* blendedPointer = (byte*)blendedData.Scan0;
                
                    for (int i = 0; i < mRec.Height; i++)
                    {
                        for (int j = 0; j < mRec.Width; j++)
                        {
                            intensity = 1-((float)(maskPointer[0] + maskPointer[1] + maskPointer[2])) / ((float)3 * 255);
                            for (int k = 0; k < 3; k++)
                            {
                                blendedPointer[k] =  (intensity>0.8)?(byte)((float)imagePointer[k]):(byte)255;
                            }
                            // 3 bytes per pixel
                            imagePointer += 3;
                            maskPointer += 3;
                            blendedPointer += 3;
                        }
    
                        // Moving the pointers to the next pixel row
                        imagePointer += imageData.Stride - (mRec.Width * 3);
                        maskPointer += maskData.Stride - (mRec.Width * 3);
                        blendedPointer += blendedData.Stride - (mRec.Width * 3);
                    }
    
                }
    
                imBase.UnlockBits(imageData);
                imMask2.UnlockBits(maskData);
                blendedImage.UnlockBits(blendedData);
            }
        }
    }
