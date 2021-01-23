    Bitmap bmp = (Bitmap)pictureBox1.Image;
    Color target = Color.FromArgb(255, 255, 255, 255); 
    Color c == bmp .GetPixel(e.X, e.Y);
    if (c == target ) 
        {
           bmp.SetPixel(e.X, e.Y, Color.Red);
           pictureBox1.Image = bmp;
        }
    else MessageBox.Show("Click only on white spots! You have hit " + c.ToString(),
                         "Wrong spot! ");
    
