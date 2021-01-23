    string headerName = "Id";
                DataTable dt = .... ;
                for (int i=0;i<dt.Columns.Count;i++)
                {
                    if (dt.Columns[i].ColumnName == headerName)
                    {
                        ViewState["CellIndex"] = i;
                       
                    }
                    
                }
          ... GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Footer)
            {
                
                int index = Convert.ToInt32(ViewState["CellIndex"]);
               
                e.Row.Cells[index].Visible = false;
            }                        
        }
