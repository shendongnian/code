    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        // Draw a picture.
        ev.Graphics.DrawImage(Image.FromFile(Global.APPDATA_PATH+ @"tmp\print.png"), ev.Graphics.VisibleClipBounds);
        // Indicate that this is the last page to print.
        ev.HasMorePages = false;
    }
