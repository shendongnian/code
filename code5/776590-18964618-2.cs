      protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
           {       
              
               Checkbox chkbx = ((Checkbox)(row.Cells[8].Controls[0]));
               bool IsChecked =chkbx.Checked ;           
               //You can write your update command here.
           }
  
     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
         {
              GridViewRow row = GridView1.Rows[e.RowIndex];
            if (e.Row.RowType == DataControlRowType.DataRow)
                {
               
               TextBox MyName= (TextBox)e.Row.FindControl("FirstName");
             
               string name = Myname.text; 
              //For checkbox
               Checkbox chkbx = (Checkbox)e.Row.FindControl("IsEnabled");
              
               if(chkbx.Checked ==true) 
                {
                    // do your stuff for checkbox checked.
                }
               else
                 {
                    // do your stuff if checkbox is not selected
                  }
               }
        }
