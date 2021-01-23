    Const int MinimumStartLocation = 0;
    Const int DistanceBetweenPanel = 15;
    private void setPanelLocation(Panel pnl)
    {
        // retreive the order of this panel
        int iPanelOrder = Convert.ToInt32(pnl.Tag);
        // the first panel must show on top and have specific location
        if(iPanelOrder == 0)
        {
             pnl.Top = MinimumStartLocation;
        }
        else
        {
             // set the top of the panel to the bottom value of the panel just before him in the order plus the constant
             pnl.Top = this.Controls.OfType<Panel>().ToList().Find(pan => Convert.ToInt32(pan.Tag) == iPanelOrder -1).Bottom + DistanceBetweenPanel;
        }
    }
