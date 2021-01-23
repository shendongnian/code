                FileStream fs = new FileStream(path, FileMode.CreateNew);
                StreamWriter CsvfileWriter = new StreamWriter(fs);
                //This Block of code for getting the Table Headers
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    tableColumns.Columns.Add(dr.GetName(i));
                }
                CsvfileWriter.WriteLine(tableColumns.Columns.ConcatUsing(","));
                
                StringBuilder sb = new StringBuilder();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        sb.AppendFormat("{0},", dr[i]);
                    }
                    sb.AppendLine();
                }
                CsvfileWriter.WriteLine(sb.ToString());
