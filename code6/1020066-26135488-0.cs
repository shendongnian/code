    protected void DatalistID_ItemDataBound(object sender, DataListItemEventArgs e) 
    {
        HiddenField hfStatusID= e.Item.FindControl("hfStatusID") as HiddenField;
        ImageButton ReceiveButton= e.Item.FindControl("ReceiveButton") as ImageButton;
        if (hfStatusID!= null && ReceiveButton!=null)
        {
            if (hfStatusID.Value == "123") // As per your Requirement
            {
                ReceiveButton.Visible= false;
            }
        }
    }
