    string[] tos = txtTo.Text.Split(';');
	for (int i = 0; i < tos.Length; i++)
	{
        string strSql = "INSERT INTO test (test1, test2) VALUES (@Content, @DateTime);";
		using (SqlConnection connection = new SqlConnection(Common.ConnetionString))
		{
			connection.Open();
			SqlTransaction tran = connection.BeginTransaction();
			try
			{
				using (SqlCommand cmd = new SqlCommand(strSql, connection, tran))
				{
                    cmd.Parameters.AddWithValue("@Content", txtContent.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                    cmd.ExecuteNonQuery();
                    tran.Commit();
				}
			}
			catch (Exception e)
			{
				tran.Rollback();  
			}
			finally
			{
				connection.Close();
				Response.Redirect("messagelist.aspx?flag=2");
			}
		}
	}
