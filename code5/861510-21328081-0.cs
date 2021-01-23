     string sqlConnectionString = @conn;
    command.CommandType = CommandType.Text;
                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    DataSet objDataset1 = new DataSet();
                    
                    objAdapter1.Fill(dt);
                  
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][5].ToString() != "")
                        {
                            DateTime dt1 = cf.texttodb(dt.Rows[0][5].ToString());
                            dt.Rows[i][5] = dt1;
                        }}
     using (SqlBulkCopy bulkCopy =
                                   new SqlBulkCopy(sqlConnectionString))
                    {
                        bulkCopy.DestinationTableName = "Tablename";
                        bulkCopy.WriteToServer(dt);
                        Label1.Text = "The Client data has been exported successfully from Excel to SQL";
                    }
