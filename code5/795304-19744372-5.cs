    protected void OnSaveClick(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpt.Items)
        {
            HiddenField hfSelected = item.FindControl("hfSelected") as HiddenField;
    
            bool selected = false;
    
            bool.TryParse(hfSelected.Value, out selected);
    
            if (selected)
            {
                HiddenField hfIID = e.Item.FindControl("hfIID") as HiddenField;
                
                int id = Convert.ToInt32(hfIID.Value);
                // do appropriate action as needed.
            }
                    
        }
    }
