    public void panelMap_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.DrawImage(mapController.GetCurrentMap(), 0, 0, panelMap.Width, panelMap.Height);
    }
