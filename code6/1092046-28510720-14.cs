        private void skyInTheWindow()
        {
            for (int i = 0; i < 100; i++)
            {
                // Loading sky into the window
                sky = new PictureBox();
                sky.Image = new Bitmap("C:/MyPath/Sky.jpg");
                sky.SetBounds(positionX, positionY, width, height);
                this.Controls.Add(sky);
                consecutivePictures.Add(sky);
                positionX += width;
            }   
        }
