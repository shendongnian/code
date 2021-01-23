    public void DrawImage(Bitmap overlay, Bitmap background, Bitmap output)
    {
        overlay.SetResolution(96, 96);
        background.SetResolution(96, 96);
        output.SetResolution(96, 96);
        using (Graphics G = Graphics.FromImage(output) )
        {
            G.DrawImage(background, 0, 0);
            G.CompositingMode = CompositingMode.SourceOver;
            G.DrawImage(overlay, 0, 0);
        }
    }
