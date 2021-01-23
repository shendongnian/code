    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          if(e.CommandName == "View/Edit")
          {
            //get row index
            int row = Convert.ToInt32(e.CommandArgument);
    
            errorLabel.Text = row.ToString();
          }
        }
