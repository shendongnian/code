    protected void grdClickDoubleClick_RowCommand(object sender, GridViewCommandEventArgs e)
     
    {
     
         GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
     
         switch (e.CommandName)
     
         {
     
              case"clk": //"clk" is command name of linkButton Row click event handler
     
                   grdClickDoubleClick.SelectedIndex = row.RowIndex;
     
              break;
     
              case"dblClk"://"dblClk" is command name of linkButton Row Double click event handler.
     
                   row.BackColor = System.Drawing.Color.Pink;
     
              break;
     
         }
     
    }
 
 
 
 
 
