     void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
               if(condition)
               {
                    Button btn = (Button)e.Row.FindControl("ButtonID");
                    btn.Visible = false;
               }
          }
     }
