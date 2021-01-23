     protected void lstSample_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblText = null;
            Boolean isColumnExists = false;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                isColumnExists  = dr.DataView.Table.Columns.Contains("Hello");
                lblText = (Label)e.Item.FindControl("lbltext");
                if (isColumnExists)
                {
                    lblText.Text = dr.Row["Hello"].ToString();
                }
                else
                {
                    lblText.Text = dr.Row["Movies"].ToString();
                }
            }
        }
