    void messageTimer_Tick(object sender, EventArgs e)
    {
        var pads = Canvas.Children.OfType<Pad>();
        if (pads != null && Layout != null)
        {
            foreach (var pad in pads)
            {
                pad.Position = new Point(pad.Position.X + random.Next(-1, 1), pad.Position.Y + random.Next(-1, 1));
            }
        }
    }
