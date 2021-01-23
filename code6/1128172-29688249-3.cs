    private readonly object _lock = new object();
    // the bitmap image is created when the program loads
    public void paint_bitmap(int data_type, string text, int x, int y)
    {
        if (data_type == 1)
        {
            lock (_lock)
            {
                using( Graphics gr2 = Graphics.FromImage(bitmap_image))
                {
                   gr2.FillRectangle(
                    Brushes.White, 
                    35 + (x * 14), 200 + (y * 18), 14, 18);
                   gr2.DrawString(
                    text, new Font("Lucida Console", 14), 
                    newBrush, 35 + (x * 14), 200 + (y * 18));
                }
            }
        }
    }
    
    //paint event
    private void main_sockets_Paint(object sender, PaintEventArgs e)
    {
        lock (_lock)
        {
           e.Graphics.DrawImage(bitmap_image, 35, 200, 1500, 700);
        }
    }
