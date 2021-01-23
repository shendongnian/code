    private readonly object _lock = new object();
    private bool _useBufferB;
    // the bitmap image is created when the program loads
    public void paint_bitmap(int data_type, string text, int x, int y)
    {
        if (data_type == 1)
        {
            // Note that this test is reversed from the Paint handler one
            using( Graphics gr2 =
                Graphics.FromImage(_useBufferB ? bitmap_image : bitmap_imageB))
            {
               gr2.FillRectangle(
                Brushes.White, 
                35 + (x * 14), 200 + (y * 18), 14, 18);
               gr2.DrawString(
                text, new Font("Lucida Console", 14), 
                newBrush, 35 + (x * 14), 200 + (y * 18));
            }
            lock (_lock)
            {
                _useBufferB = !_useBufferB;
            }
        }
    }
    
    //paint event
    private void main_sockets_Paint(object sender, PaintEventArgs e)
    {
        lock (_lock)
        {
           e.Graphics.DrawImage(
               _useBufferB ? bitmap_imageB : bitmap_image, 35, 200, 1500, 700);
        }
    }
