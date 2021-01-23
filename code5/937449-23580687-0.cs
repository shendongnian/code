       protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int columnIndex = 0;
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    if (cell.ContainingField is BoundField)
                        if (((BoundField)cell.ContainingField).DataField.Equals("tid"))
                            break;
                    columnIndex++;
                }
                string columnValue = e.Row.Cells[columnIndex].Text;              
                string[] splitString = columnValue.Split(' ');
                string tid = splitString[1];
                e.Row.Cells[columnIndex].Text = tid.Remove(5,3);
            }          
        }  
