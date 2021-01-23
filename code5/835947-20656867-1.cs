    protected void gvDynamicArticle_RowDataBound(object sender, GridViewRowEventArgs e) 
    {
        for (int j = 1; j < e.Row.Cells.Count; j++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkButton = new LinkButton();
                lnkButton.ID = string.Format("lnkButton{0}{1}", e.Row.DataItemIndex, j);
                lnkButton.Click += new EventHandler(lnkButton_Click);
                    
                Label tempLabel = e.Row.FindControl("Label" + j) as Label;
                lnkButton.Text = tempLabel.Text;
                lnkButton.CommandArgument = tempLabel.Text;
    
                tempLabel.Visible = false;
    
                e.Row.Cells[j].Controls.Add(lnkButton);
            }
        }
    }
