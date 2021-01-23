    SqlCommand comando = new SqlCommand();
    comando.Transaction = trx;
    comando.Connection = conexao;
    
    for (int j = 0; j < arr.Length; j++) {
        comando.CommandText = "UPDATE RECURSO_CLIENTE SET NM_CLIENTE = " +  arr[j].Col3 + " WHERE CD_RECURSO = " + arr[j].Col1;
        comando.ExecuteNonQuery();
    }
    
    trx.Commit();
