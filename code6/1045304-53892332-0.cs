        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           ListViewItem Item = ((LinkButton)sender).NamingContainer as 
            ListViewItem;
            if (Item != null)
            {
                //for DataKeys
                int Klub_ID = (int)ListView1.DataKeys[Item.DataItemIndex] 
                ["KlubID"];
                //for any labl in your ListView
                Label lblImeKlubaLabel = 
                 (Label)Item.FindControl("ImeKlubaLabel");
                Session["Duration"] = lblImeKlubaLabel.Text;
               
            }
         }
