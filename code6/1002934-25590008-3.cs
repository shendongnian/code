        protected void rptMyRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            System.Data.DataRowView dataItem = e.Item.DataItem as System.Data.DataRowView;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txtMyTextBox = e.Item.FindControl("txtMyTextBox") as TextBox;
                txtMyTextBox.Text = dataItem.Row["Title"].ToString();
                Button btnSowID = e.Item.FindControl("btnSowID") as Button;
                btnSowID.CommandArgument = dataItem.Row["ID"].ToString();
                Button btnShowTitle = e.Item.FindControl("btnShowTitle") as Button;
                btnShowTitle.CommandArgument = dataItem.Row["Title"].ToString();
                if (Convert.ToInt32(dataItem.Row["ID"]) % 2 == 0)
                {
                    btnSowID.Visible = false;
                    btnShowTitle.Visible = false;
                }
            }
        }
