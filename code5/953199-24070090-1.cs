    protected void test_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            Literal name;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                name = (Literal)e.Item.FindControl("litName");
                name.Text = [Grab Your Property Value Here];
            }
        }
