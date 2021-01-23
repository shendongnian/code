                DataRowView drv = e.Item.DataItem as DataRowView;
                System.Web.UI.WebControls.Label LabelColor = e.Item.FindControl("LabelColor") as System.Web.UI.WebControls.Label;
                if (e.Item.ItemType == ListItemType.Item && LabelColor != null)
                {
                    LabelColor.Text = drv.Row["ColorLotName"].ToString(); 
                }
                System.Web.UI.WebControls.Label LabelColorAlternating = e.Item.FindControl("LabelColorAlternating") as System.Web.UI.WebControls.Label;
                if (e.Item.ItemType == ListItemType.AlternatingItem && LabelColorAlternating != null)
                {
                    LabelColorAlternating.Text = drv.Row["ColorLotName"].ToString();            
                }
