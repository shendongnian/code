    public DataSet MySQL_Select(string query)
            {
                MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;
                msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=" + MYSQL_SERVER + ";user id=" + MYSQL_login + ";Password=" + MYSQL_password + ";database=" + MYSQL_SCHEMAS + ";persist security info=False; Allow Zero Datetime=true ");
    DataSet DS = new DataSet();
                try
                 {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, msqlConnection);
                    mySqlDataAdapter.Fill(DS);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    msqlConnection.Close();
                }
                return (DS);
            }
