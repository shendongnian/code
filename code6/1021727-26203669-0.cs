    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = e.Item as GridFooterItem;
            string str = "Total Amount: $" + item["ID"].Text;
            Label literal = new Label();
            literal.Text = str;
            literal.ID = "lblDtlTransAmount";
            item["ID"].Controls.Add(literal);
        }
    }
