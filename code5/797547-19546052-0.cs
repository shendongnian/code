        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap sepiaEffect = (Bitmap)pictureBox.Image.Clone();
            for (int yCoordinate = 0; yCoordinate < sepiaEffect.Height; yCoordinate++)
            {
                for (int xCoordinate = 0; xCoordinate < sepiaEffect.Width; xCoordinate++)
                {
                    Color color = sepiaEffect.GetPixel(xCoordinate, yCoordinate);
                    double grayColor = ((double)(color.R + color.G + color.B)) / 3.0d;
                    Color sepia = Color.FromArgb((byte)grayColor, (byte)(grayColor * 0.95), (byte)(grayColor * 0.82));
                    sepiaEffect.SetPixel(xCoordinate, yCoordinate, sepia);
                }
            }
            pictureBox.Image = sepiaEffect;
        }
