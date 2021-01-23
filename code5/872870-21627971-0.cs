	if (reader.HasRows)
    {
        while (reader.Read())
		{
			sqlComm.Parameters.AddWithValue("@CODIGO", reader[0]);
			sqlComm.Parameters.AddWithValue("@NF_CONTA", reader[1]);
			sqlComm.Parameters.AddWithValue("@TEXTO", reader[2]);
			sqlComm.ExecuteNonQuery();
		}
    }
