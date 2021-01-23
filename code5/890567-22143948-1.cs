    using (SqlConnection sconn = new SqlConnection(sqlconn))
    {
      sconn.Open();
      for (int i = 0; i < dtExcel.Rows.Count;  i++)
                {
                   try
                   {                                 
                      string insert_query12 = "insert into FCROperation (CallingNumber,OperatorId,OperatorName,CallReason) values("+dtExcel.Rows[i][0]+","+dtExcel.Rows[i][1]+",'"+dtExcel.Rows[i][2]+"','"+dtExcel.Rows[i][3]+"')";
                      SqlCommand cmd = new SqlCommand(insert_query12,sconn);
                      count+=cmd.ExecuteNonQuery();            
                    }
                 catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                   {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                   }
                   Console.WriteLine(errorMessages.ToString());
                }
                    catch (Exception ex)
                    {
                       //continue;             
                    }
                    //Label1.Text = ex.Message;
                 }
    }
