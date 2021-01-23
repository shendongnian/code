    var dataTable = new DataTable();
	dataTable.Columns.Add("Col1", typeof(int));
	dataTable.Columns.Add("Col3", typeof(int));
	for (int j = 0; j < arr.Length; j++) 
	{
		var newRow = dataTable.NewRow();
		newRow[0] = arr[j].Col1;
		newRow[1] = arr[j].Col3;
		dataTable.Rows.Add(newRow);
	}
	string sql = @"	MERGE RECURSO_CLIENTE rc
					USING @UpdateValues u
						ON rc.CD_RECURSO = u.Col1
					WHEN MATCHED UPDATE
						SET NM_CLIENTE = u.Col3;";
	using (var conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["strConexao"].ToString()))
	using (var comando = new SqlCommand(sql, conexao))
	{
		conexao.Open(); 
		var tableParam = new SqlParameter("@UpdateValues", SqlDbType.Structured);
		tableParam.TypeName = "@YourTypeName";
		tableParam.Value = dataTable;
		comando.Parameters.Add(tableParam);
		comando.ExecuteNonQuery();
	}
