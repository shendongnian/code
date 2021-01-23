     int j = 0;
    foreach (DataGridViewRow row in grid_stock.Rows)
                {
                  bool vc = Convert.ToBoolean(grid_stock.Rows[j].Cells[0].Value);
                    if (vc == true)
                    {
                       //Here my inserting to sql db
                       j++;
                    }
                }
                    else
                    {
                        j++;
                    }
