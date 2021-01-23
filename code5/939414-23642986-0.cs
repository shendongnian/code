    protected void repRunResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //capture current context.
        Repeater repRunResults = (Repeater)sender;
        Label laMessage = e.Item.FindControl("laMessage"); //<-- Used e.Item here
        DSScatterData.RunResultsRow rRunResults = (DSScatterData.RunResultsRow)((DataRowView)(e.Item.DataItem)).Row;
    
        //show message if needed.
        int iTotal = this.GetTotal(m_eStatus, rRunResults.MaxIterations, rRunResults.TargetLimit);
        if(iTotal == 100)
        {
            laMessage.Text = "The computed total is 100.";
        }
        else
        {
            laMessage.Text = "The computed total is NOT 100.";
        }
    }
