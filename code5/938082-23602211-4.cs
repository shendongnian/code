    protected void rptQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    String question = (String)e.Item.DataItem;
                    Label lblQuestion = (Label)e.Item.FindControl("lblQuestion");
                    lblQuestion.Text = question;
                }
            }
      
