    public int CreateClienteInfo(ClienteInfo CI)
    {
    
        int result;
        string cmdText = @"INSERT INTO clienti ( nome_cliente ) VALUES ( nome_cliente );
                           Select LAST_INSERT_ID();";
    
        using(MySqlConnection conn = new MySqlConnection(....connectionstring .....))
        using(MySqlCommand cmd = new MySqlCommand(cmdText, conn);
        {
            conn.Open()
            cmd.Parameters.AddWithValue("@nome_cliente", CI.nome_cliente);
            result = Convert.ToInt32(cmd.ExecuteScalar())
            return result;
        }
    }
