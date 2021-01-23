     string validEntry = textBox1.Text; //Y
   
     protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               if(validEntry == 'Y')
                  e.Row.Enabled = false;
        
           }
      }
