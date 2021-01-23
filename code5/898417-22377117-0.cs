    for(int i = 0; i < listBox1.Items.Count; i++)
    {
        Application.DoEvents();
        var frame = new Bitmap(name);
        g.DrawImage(frame, 0, 0, width, height);
        writer.WriteVideoFrame(image);
    }
