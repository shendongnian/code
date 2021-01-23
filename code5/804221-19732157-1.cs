    string sqlCom = String.Format(@"SELECT [Version],version2 FROM ConfigSystem");
            SqlConnectionStringBuilder ConnectionString = new SqlConnectionStringBuilder();
            ConnectionString.DataSource = SQL06;
            ConnectionString.InitialCatalog = "SuperSweetdb";
            ConnectionString.IntegratedSecurity = true;
            SqlConnection cnn = new SqlConnection(ConnectionString.ToString());
                
            using (var version = new SqlCommand(sqlCom, cnn))
            {           
                cnn.Open();
                using(IDataReader dataReader = version.ExecuteReader()) 
                {
                    while (dataReader.Read())
                    {
                        label7.Text = dataReader["Version"].ToString();
                        label9.Text = dataReader["VertexDataVersion"].ToString();
                    }
                }
            };   
