    MySqlConnection conn;
    public MySqlConnection Conn
            {
                get
                {
                    if ((conn == null) || (conn.State == System.Data.ConnectionState.Closed))
                    {
    
                        Connect();
                    }
    
                    return conn;
                }
                set
                {
                    conn = value;
                }
            }
    public override void Connect()
            {
                RetornaDadosIniParaClasse();
                conn = new MySqlConnection(StringConnection);
    
                try
                {
                    conn.Open();
    
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        throw new AccessDatabaseException("Conexão com o banco de dados firebird fechada");
                    }
                }
                catch (Exception ex)
                {
                    throw new AccessDatabaseException(ex.Message);
                }
            }
