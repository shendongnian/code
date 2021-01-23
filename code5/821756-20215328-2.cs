     void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      //change the value to `string x = dt.ToString("MM-dd-yyyy");`
         if(e.Row.RowType == DataControlRowType.DataRow)
        {
          
          string time = ((Label)e.Row.FindControl("UpdateDate")).Text;
         // string time =Convert.ToString(e.Row.Cells[7].Text);
          e.Row.Cells[7].Text =time.ToString("MM-dd-yyyy");`
    
        }
    }
