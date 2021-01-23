       try
        {
             SqlCommand command = new SqlCommand(strSql);
             command.Connection = new SqlConnection(PO_ConnectionString);
             command.CommandType = CommandType.Text;
             command.Parameters.Add(new SqlParameter("@ExternalRef",SqlDbType.NVarChar ,50){Value ="EDE01"});
             command.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int) { Value = 24});
             command.Connection.Open();
             var result = command.ExecuteScalar();
             if (result != null)
             {
                 return (int)result;
             }
             else
             {
                 return 0;
             }
    }
    
     catch (Exception ex)
    {
      MessageBox.Show(ex.Message);
    }
    
     
