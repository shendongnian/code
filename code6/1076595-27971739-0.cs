    private bool _isSelecting;
    private Rectangle _selectionRectangle;
    private void Form1_Load(object sender, EventArgs e)
    {
        _isSelecting = false;
    }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _selectionRectangle = new Rectangle(e.X, e.Y, 0, 0);
            pictureBox1.Invalidate();
            _isSelecting = true;
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _selectionRectangle = new Rectangle(_selectionRectangle.Left, _selectionRectangle.Top,
                e.X - _selectionRectangle.Left, e.Y - _selectionRectangle.Top);
            pictureBox1.Invalidate();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (!_isSelecting)
            return;
        using (var pen = new Pen(Color.Red, 2))
        {
            e.Graphics.DrawRectangle(pen, _selectionRectangle);
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        using (var bmp = new Bitmap(pictureBox1.Image))
        {
            if (_selectionRectangle.Width + _selectionRectangle.X > pictureBox1.Image.Width)
                _selectionRectangle.Width = pictureBox1.Image.Width - _selectionRectangle.X;
            if (_selectionRectangle.Height + _selectionRectangle.Y > pictureBox1.Image.Height)
                _selectionRectangle.Height = pictureBox1.Image.Height - _selectionRectangle.Y;
            var selectedBmp = bmp.Clone(_selectionRectangle, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pictureBox1.Image = selectedBmp;
        }
        _isSelecting = false;
        pictureBox1.Invalidate();
    }
