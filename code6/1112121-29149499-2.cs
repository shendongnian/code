    using (SqlConnection con = new      SqlConnection(utilityClass.GetConnectionString(environ)))
                 {
                con.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = "dbo.inserttablename";
                    try
                    {
                        bulkCopy.WriteToServer(mfsentdata);
                    }
                    catch (SqlException e)
                    {
                        CustomException.Write(CustomException.CreateExceptionString(e, mfsentdata.TableName));
                    }
                }
                con.Close();
            }
        }
              
             
               
