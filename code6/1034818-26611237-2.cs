    foreach(TableCell cell in row.Cells)
     {
       if(cell.HasControls() == true)
        {
          if(cell.Controls[0].GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
           {
               CheckBox chk = (CheckBox)cell.Controls[0];
               if(chk.Checked)
                {
                   cell.Text = "1";
                }
               else{
                    cell.Text = "0";
                   }
           }
        }
     }
