	SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["strConexao"].ToString());
    conexao.Open();
    SqlTransaction trx = conexao.BeginTransaction();
    try
    {
        for (int j = 0; j < arr.Length; j++) {
		    var commandText = "UPDATE RECURSO_CLIENTE SET NM_CLIENTE = " +  arr[j].Col3 + " WHERE CD_RECURSO = " + arr[j].Col1;
			SqlCommand comando = new SqlCommand(commandText, conexao, trx);
            comando.ExecuteNonQuery();
        }
        trx.Commit();
        return 1;
    }
    catch (SqlException ex)
    {
        try
        {
            trx.Rollback();
            return 0;
        }
        catch (Exception exRollback)
        {
            return 0;
        }  
    }
