    protected void OnSaveClick(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpt.Items)
        {
            HiddenField hfSelected = item.FindControl("hfSelected") as HiddenField;
    
            bool selected = false;
    
            bool.TryParse(hfSelected.Value, out selected);
    
            if (selected)
            {
                // do appropriate action as needed.
            }
                    
        }
    }
