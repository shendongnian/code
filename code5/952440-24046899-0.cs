    foreach (DataTable dt in ds.Tables)
                    {
                        // checking whether the table selected from the dataset exists in the database or not
    
    
                       string exists=null;
                       try
                       {
                           SqlCommand cmd = new SqlCommand("SELECT * FROM sysobjects where name = '" + dt.TableName + "'", sqlcon);
                           exists = cmd.ExecuteScalar().ToString();
                       }
                       catch (Exception exce)
                       {
                           exists = null;
                       }
                                               
    
                   // if does not exist
                        
    
                      if(exists==null)
                      {
                          // selecting each column of the datatable to create a table in the database
    
    
                            foreach (DataColumn dc in dt.Columns)
                            {
                                 if (exists == null)
                                 {
                                SqlCommand createtable = new SqlCommand("CREATE TABLE " + dt.TableName + " (" + dc.ColumnName + " varchar(MAX))", sqlcon);
                                createtable.ExecuteNonQuery();
                                exists = dt.TableName;
                                 }
                                 else
                                 {
                                SqlCommand addcolumn = new SqlCommand("ALTER TABLE "+dt.TableName+" ADD "+dc.ColumnName+" varchar(MAX)",sqlcon);
                                addcolumn.ExecuteNonQuery();
                                 }
                            }
    
    
                          // copying the data from datatable to database table
    
    
                            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlcon))
                            {
                                bulkcopy.DestinationTableName = dt.TableName;
                                bulkcopy.WriteToServer(dt);
                            }
                      }
                   // if table exists, just copy the data to the destination table in the database
    
    
                      else
                      {
                            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlcon))
                            {
                                bulkcopy.DestinationTableName = dt.TableName;
                                bulkcopy.WriteToServer(dt);
                            }
                      }
                    }
