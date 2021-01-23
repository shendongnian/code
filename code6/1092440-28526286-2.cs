    e.Graphics.SetClip(clip);
    using (Bitmap bitmap = new Bitmap(ClientSize.Width, ClientSize.Height))
    {
        using (Graphics G = Graphics.FromImage(bitmap))
                G.CopyFromScreen(dstPoint, srcPoint, 
                                 copySize, CopyPixelOperation.SourceCopy);
        e.Graphics.DrawImage(bitmap, 0, 0);
    }
