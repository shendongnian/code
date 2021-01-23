            using (var connection = new SqlConnection("My Connection String"))
           {
               SqlTransaction transaction = connection.BeginTransaction();
    
                    try
                    {
                        DataSet DocNum = new DataSet();
    
                        string sDocNumber = "";
                        string[] taleNamesDoc = new string[1];
                        taleNamesDoc[0] = "docnumber";
                        SqlParameter[] paramDoc = new SqlParameter[1];
                        paramDoc[0] = new SqlParameter("@DocumentNumber", DocNumber.ToString().Trim());
    
                        SqlHelper.FillDataset(transaction, CommandType.StoredProcedure, "spGetDocumentDetailsByNumber", DocNum, taleNamesDoc, paramDoc);
                        string docTitle = DocNum.Tables["docnumber"].Rows[0][0].ToString();
    
    
                        transaction.Commit();
    
                        return docTitle;
                    }
                    catch (Exception ex)
                    {
    
                        transaction.Rollback();
                        throw; // ex; - You will loose your stack trace. Just throw;, so that the stack history goes with it. 
                    }
            }  // Connection is disposed and cleaned up. 
        }
