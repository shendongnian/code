    for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    if (datatable.Columns[i].ColumnName.Contains("Column"))
                    {
                        datatable.Columns.RemoveAt(i);
                        i--;
                    }
                }
