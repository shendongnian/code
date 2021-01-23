    try
        {
            string sqlComandoString = "SELECT codPesquisa, titulo FROM Pesquisas ORDER BY codPesquisa DESC;";
            SqlCommand sqlComando = new SqlCommand(sqlComandoString, sqlConexao);
            sqlConexao.Open();
            DDLPesquisa.DataSource = sqlComando.ExecuteReader();
            DDLPesquisa.DataTextField = "titulo";
            DDLPesquisa.DataValueField = "codPesquisa";
            DDLPesquisa.DataBind();
            sqlConexao.Close();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("########## Erro na obtenção dos valores das questões: " + ex.Message.ToString());
        }
