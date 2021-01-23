      public void change_header()
            {
                DisplayDataGrid();
                grid_detail.Columns.Clear();
    
                foreach (DataGridViewColumn c in grid_display.Columns)
                {
                    grid_detail.Columns.Add(c.Clone() as DataGridViewColumn);
                }
            }
