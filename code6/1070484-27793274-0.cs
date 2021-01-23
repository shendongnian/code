                        var columns = new List<string>();
                        DbCommand cmd = cnn.CreateCommand("SELECT * FROM Table1",  CommandType.Text);
                        DataTable Dt= cnn.GetDataTable(cmd);
						foreach (System.Data.DataColumn col in dt.Columns)
                        {
                            columns.Add(col.ColumnName);
                        }
