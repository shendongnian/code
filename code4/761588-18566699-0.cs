    protected void dlDelivery_DataBound(object sender, DataListItemEventArgs e)
    {
        RadioButton rdoOther = e.Item.FindControl("rdoOther") as RadioButton;
        
        //rdoOther  will be null if ListItemType is not footer.
        if (rdoOther !=null && rdoOther.Checked)
        {
            // Do your tasks
        }
    }
