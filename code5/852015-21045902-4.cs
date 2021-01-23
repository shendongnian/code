    private void timer_Tick(object sender, EventArgs e)
    {
        // presuming that you made a separate user control
        // which has a collection of ellipses in a `Clouds` property
        foreach (var c in cloudBox.Clouds)
            Animate(c);
        cloudBox.Invalidate();
    }
    private void Animate(Ellipse c)
    {
        // update diameter
        c.Diameter += c.DiameterDelta;
        // when you reach bounds, change delta direction
        if ((c.DiameterDelta < 0 && c.Diameter <= 5) ||
            (c.DiameterDelta > 0 && c.Diameter >= 25))
            c.DiameterDelta = -c.DiameterDelta;
    }
