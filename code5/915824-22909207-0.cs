    protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
        foreach (ListItem item in ((DropDownList)sender).Items)
        {
            string i = item.Value;
    //Check the condition from the database whether it is Check in or not
    // if check in then find out the value of user e.g userID
            if (i == "1")//instead of "1" you pass the User id who checkedIn 
            {
                item.Attributes.Add("style", "color:Green;font-weight:bolder");
                item.Attributes.Add("disabled", "disabled");
            }
        }
        }
