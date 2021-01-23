    private void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
             string header1;
             string header2;
             string header3;
             string header4;
             // Retrieve headers from database and assign to variables
             SetHeaderValue(e.Item, "litHeader1", header1);
             SetHeaderValue(e.Item, "litHeader2", header2);
             SetHeaderValue(e.Item, "litHeader3", header3);
             SetHeaderValue(e.Item, "litHeader4", header4);
        }
    }
    private void SetHeaderValue(RepeaterItem item, string litId, string headerText)
    {
        var lit = item.FindControl(litId) as Literal;
        if (lit != null)
            lit.Text = headerText;
    }
