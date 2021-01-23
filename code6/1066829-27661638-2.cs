    public static SizeF GetCurrentDpi()
    {
        using (Form form = new Form())
        using (Graphics g = form.CreateGraphics())
        {
            var result = new SizeF()
            {
                Width = g.DpiX,
                Height = g.DpiY
            };
            return result;
        }
    }
