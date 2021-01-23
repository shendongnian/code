    private void panel1_VisibleChanged(object sender, EventArgs e)
    {
        // use sending object
        Panel panel = sender as Panel;
        if (panel.Visible == false)
            ;
        // alternate use name of object
        if (panel1.Visible == false)
            ;
    }
