    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         //here you put the if statement to get the "OpenHouse" column value
         if(e.Row.Cells[Column Index].Text.Equals("Yes")){
             //your code here
         }
    }
