      public DataTable Filter(DataTable table)
                {
                    DataView view = new DataView(table);
                    view.RowFilter = "Camp IS NULL"; 
                    table = view.ToTable();
                    return table;
                }
