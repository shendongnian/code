          void gvVegetationZone_RowDataBound(object sender, GridViewRowEventArgs e)
         {
            if(e.Row.RowType == DataControlRowType.DataRow)  
            {
                 string cellVALUE = e.Row.Cells[1].Text;
                 switch(cellVALUE )
                 {
                  case :
                   e.Row.Cells[1].Text = "column value";
       
                 }
        }
       }
