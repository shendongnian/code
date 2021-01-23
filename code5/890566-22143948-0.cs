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
                    catch (Exception ex)
                    {
                       //continue;             
                    }
                    //Label1.Text = ex.Message;
                 }
    }
