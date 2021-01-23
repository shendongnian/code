	for (int j = 0; j < arr.Length; j++) 
	{
		using (var comando = new SqlCommand("UPDATE RECURSO_CLIENTE SET NM_CLIENTE = @Col3 WHERE CD_RECURSO = @Col1", conexao))
		{
			comando.Transaction = trx;
			comando.Parameters.AddWithValue("@Col3", arr[j].Col3);
			comando.Parameters.AddWithValue("@Col1", arr[j].Col1);
			comando.ExecuteNonQuery();
		}
    }
