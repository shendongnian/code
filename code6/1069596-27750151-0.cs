            // Your Images
            Image img1 = pictureBox1.Image;
            Image img2 = pictureBox2.Image;
            // Now set as bitmap
            Bitmap bmp1 = new Bitmap(img1);
            Bitmap bmp2 = new Bitmap(img2);
            // here will be stored the bitmap data
            byte[] byt1 = null;
            byte[] byt2 = null;
            // Get data of bmp1
            var bitmapData = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp1.PixelFormat);
            var length = bitmapData.Stride * bitmapData.Height;
            //
            byt1 = new byte[length];
            //
            Marshal.Copy(bitmapData.Scan0, byt1, 0, length);
            bmp1.UnlockBits(bitmapData);
            // Get data of bmp2
            var bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp2.PixelFormat);
            var length2 = bitmapData2.Stride * bitmapData2.Height;
            //
            byt2 = new byte[length2];
            //
            Marshal.Copy(bitmapData2.Scan0, byt2, 0, length2);
            bmp2.UnlockBits(bitmapData2);
            // And now compares these arrays
            if (StructuralComparisons.StructuralEqualityComparer.Equals(byt1, byt2))
            {
                MessageBox.Show("Is Equal");
            }
            else
            {
                MessageBox.Show("Isn`t equal");
            }
