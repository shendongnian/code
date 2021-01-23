        static public DataTable RunSQL(string sSQL, MySqlConnection MyConnection)
        {
            DataTable DT = new DataTable();
            using (MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(sSQL, MyConnection))
            {
                try
                {
                    #region Executa / Preenche o DT
                    DT.TableName = "TABELA";
                    MyDataAdapter.Fill(DT);
                    #endregion
                }
                catch (Exception ex)
                {
                    // by Tony - 26-set-2006 
                    // Retorna o SQL e o erro, para facilitar o debug do sistema.
                    var newexeption = new Exception(sSQL + " " + ex.Message);
                    throw newexeption;
                }
            }
            return DT;
        }
    public void SearchByname(string name)
    {
        string query = "select * from bloodbank Where name = '"+ name +"'";
        try
        {
            DataTable DT_Results;
            using(MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                DT_Results = RunSQL(query, conn);
            }
            foreach(DataRow dr in DT_Results.Rows)
            {
                Console.WriteLine("ID: ", dr.Field<string>("id"));
                Console.WriteLine("Name: ", dr.Field<string>("name"));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
