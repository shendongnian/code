    public void Paint(PaintEventArgs e)
    {
        Icon IconCamera = new Icon("cam.ico");
        Rectangle rect = new Rectangle(100, 100, 32, 32);
        e.Graphics.DrawIcon(IconCamera, rect);
    }
