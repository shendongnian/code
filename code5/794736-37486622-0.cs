    private void panelVibility(Control ctr)
    {
        foreach (Control item in this.Controls)
        {
            if (item.Name.StartsWith("pnl"))
            {
                item.Location = new Point(12, 27);
                item.Visible = false;
            }
        }
        ctr.Visible = true;
    }
