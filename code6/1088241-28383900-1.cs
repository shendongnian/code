    Bitmap bmp = (Bitmap)pictureBox1.Image;
    Color c = bmp .GetPixel(e.X, e.Y);
    if (c = color.White) 
        {
           bmp.SetPixel(e.X, e.Y, Color.Red);
           pictureBox1.Image = bmp;
        }
    else MessageBox.Show("Click only on white spots", "Wrong spot");
    
