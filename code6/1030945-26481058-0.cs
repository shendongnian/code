    foreach(GridViewRow row in gridCriteria.Rows)
        {
          foreach(TableCell cell in row.Cells)
          {
              if(cell.Text != "")
              {
                    int indexOf = row.Cells.GetCellIndex(cell);
                  if(indexOf == 0)
                  {
                      Sum += Convert.ToInt32(cell.Text);
                  }
                  else
                  {
                      Sum *= Convert.ToInt32(cell.Text);
                  }
             }
          }
        }
