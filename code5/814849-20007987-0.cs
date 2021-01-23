    command.Parameters.Add(@"v1", SqlDbType.VarChar).Value = TextBox1.Text;
    command.Parameters.Add(@"v2", SqlDbType.Int).Value = 0;
    command.Parameters.Add(@"v3", SqlDbType.Int).Value = 0;
    command.Parameters.Add(@"v4", SqlDbType.VarBinary).Value = FileUpload1.FileBytes;
    command.Parameters.Add(@"v5", SqlDbType.VarChar).Value = TextBox3.Text;
    command.Parameters.Add(@"v6", SqlDbType.VarChar).Value = TextBox4.Text;
    command.Parameters.Add(@"v7", SqlDbType.VarChar).Value = TextBox5.Text;
    
    command.Prepare();
    
    command.ExecuteNonQuery();
    
    conn.Close();
