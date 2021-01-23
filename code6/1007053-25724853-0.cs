    public virtual int GetIndexByCaption(string caption, DataTable dt)
            {
                int columnIndex = -1;
                try
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.Caption == caption)
                        {
                            columnIndex = dt.Columns.IndexOf(column);
                            break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return columnIndex;
            }
