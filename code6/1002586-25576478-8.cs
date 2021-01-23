    conn.Open();
    SqlParameter prm = command.Parameters.Add(new SqlParameter("@RowCount", SqlDbType.Int));
    prm.Direction = ParameterDirection.Output;
    command.ExecuteNonQuery();
    Console.WriteLine(prm.Value.ToString());
    conn.Close();
