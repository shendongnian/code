    private SqlConnection sqlConn = new SqlConnection();
    private System.Data.DataSet dataSet = new System.Data.DataSet();
    private System.Data.DataTable dataTable;
    private System.Data.DataRow dataRow;
    
    private SqlCommand search(string searchParam, int searchOption)
        {
            SqlCommand command = new SqlCommand();
            string sql;
            string[] allWords = searchParam.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (searchOption == 1)
            {
                sql = "SELECT Livros.ISBN, Livros.Titulo, Livros.Tema, Livros.Resumo, Livros.Imagem, Livros.fotoTipo, Editoras.Nome AS nomeEditora FROM Livros INNER JOIN Editoras ON Livros.codEditora = Editoras.codEditora WHERE ";
            }
            else
            {
                sql = "SELECT Livros.ISBN, Livros.Titulo, Livros.Tema, Livros.Resumo, Livros.Imagem, Livros.fotoTipo, Editoras.Nome AS nomeEditora FROM Livros INNER JOIN livrosAutores ON Livros.ISBN = livrosAutores.ISBN INNER JOIN Autores ON livrosAutores.idAutor = Autores.idAutor INNER JOIN Editoras ON Livros.codEditora = Editoras.codEditora WHERE ";
            }
            using (command)
            {
                for (int i = 0; i < allWords.Length; ++i)
                {
                    if (i > 0)
                    {
                        sql += "OR ";
                    }
                    if (searchOption == 1)
                    {
                        sql += string.Format("(Livros.Titulo LIKE '%{0}%') ", allWords[i]);
                    }
                    else
                    {
                        sql += string.Format("(Livros.Autor LIKE '%{0}%') ", allWords[i]);
                    }
                }
                command.CommandText = sql;
            }
            return command;
        }
    protected void Bind()
        {
                sqlConn.ConnectionString = Properties.Settings.Default.BibliotecaConnectionString;
                string connectionString = sqlConn.ConnectionString.ToString();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(search(searchText, searchOption).CommandText, connectionString);
                sqlDataAdapter.Fill(dataSet, "livrosTitulo");
                dataTable = dataSet.Tables["livrosTitulo"];
                dataGrid.DataContext = dataTable.DefaultView;
        }
