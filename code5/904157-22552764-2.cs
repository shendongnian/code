    public void Paint(PaintEventArgs e)
    {
        if (checkBox1.Checked)
        {
            Rectangle rect = new Rectangle(100, 100, 32, 32);
            e.Graphics.DrawIcon(IconCamera, rect);
            Icon IconCamera = new Icon("cam.ico");
        }
    }
