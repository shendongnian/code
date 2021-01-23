        String previousName = "";
        protected void MyDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label Label1 = (Label)e.Item.FindControl("Label1");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string currentName = rowView["Name"].ToString();
                if (currentName == previousName)
                {
                    Label1.Text = "";
                }
                else
                {
                    Label1.Text = currentName;
                }
                previousName = currentName;
            }
            
        }
