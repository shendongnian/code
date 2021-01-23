    Bitmap _cached = null;
    override void OnPaint(PaintEventArgs e)
    {
        if(_cached == null)
        {
            _cached = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using(var graphics = Graphics.FromImage(_cached)
            {
                 // draw into this graphics once -> it will be cached in _cached bitmap
            }
        }
        e.Graphics.DrawImage(_cached, Point.Empty);
    }
    // call this if _zoom or ClientSize is changed
    void ResetCache()
    {
        _cache = null;
        this.Invalidate(); // mandatory for _zoom change
    }
