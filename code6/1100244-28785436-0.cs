           //Load an image in from a file
           Bitmap pImage = new Bitmap(Environment.CurrentDirectory + @"\Image.bmp", true);
           //Set our picture box to that image
           pictureBox1.Image = (Bitmap)pImage.Clone();
           //Store our old image so we can delete it
           Image oldImage = pictureBox1.Image;
           //Pass in our original image and return a new image rotated 35 degrees right
           pictureBox1.Image = RotateImage(pImage, 270);
           if (oldImage != null)
           {
               oldImage.Dispose();
           } 
