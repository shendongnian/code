    protected void ddl_Customers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = ddl_Customers.SelectedValue.ToString();
        // map the string to the List<string>
        var collection = new DAL.collection();
        collection.Add(selectedValue);
    
        //populate the text boxes
        txtSupportRef.Text = bobj.returnTicket(collection);
    }
