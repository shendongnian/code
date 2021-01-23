                var clonedDT = dt.Clone();
                for (int i = 0; i < clonedDT.Columns.Count; i++)
                {
                    clonedDT.Columns[i].DataType = typeof(String);
                }
             
                for (int j = 0; j < dt.Rows.Count;j++ )
                {
                    var newRow = clonedDT.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {                        
                        newRow.SetField(i, Convert.ToString(item.Value.Rows[j]  [i]));
                    }
                    clonedDT.Rows.Add(newRow); 
                }
