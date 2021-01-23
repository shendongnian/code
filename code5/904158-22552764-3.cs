    public void Paint(PaintEventArgs e)
    {
        if (checkBox1.Checked)
        {
            Rectangle rect = new Rectangle(100, 100, 32, 32);
            Icon IconCamera = new Icon("cam.ico");
            e.Graphics.DrawIcon(IconCamera, rect);
        }
    }
