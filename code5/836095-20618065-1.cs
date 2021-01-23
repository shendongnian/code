    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
            DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));
    
        // Sort the DropDownList's Items by descending
        SortListControl(MyDropDownList, false);
    }
