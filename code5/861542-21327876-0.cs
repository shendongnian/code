    protected void quan_TextChanged(object sender, EventArgs e)
    {
        TextBox t = (TextBox)sender;
        DataListItem item = (DataListItem)t.NamingContainer;
        int amount = int.Parse(((TextBox)item.FindControl("quan")).Text);
        DataTable dt = se.GetAllFlights();
        string price = dt.Rows[item.ItemIndex][4].ToString();
        int pos = price.IndexOf("$");
        price = ((int.Parse(price.Substring(0, pos))) * (int.Parse(t.Text))).ToString() + "$";
        dt.Rows[item.ItemIndex][4] = price.ToString();
        dlOrders.DataSource = dt;
        dlOrders.DataBind();        
    }
