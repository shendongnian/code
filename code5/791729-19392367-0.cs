    public string[] getColumnsName()
        {
            List<string> listacolumnas=new List<string>();
            using (SqlConnection connection = new SqlConnection(Connection))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select column_name from information_schema.columns where table_name = 'Usuarios'";
                connection.Open(;
                using (var reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                {
                    reader.Read();
    
                    var table = reader.GetSchemaTable();
                    foreach (DataColumn column in table.Columns)
                    {
                        listacolumnas.Add(column.ColumnName);
    
                    }
                }
            }
            return listacolumnas.ToArray();
        }
