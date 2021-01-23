          string connectionString = fmDbSelect();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    var scripts = Regex.Split(sql, @"\bGO\b", RegexOptions.Multiline);
                    //var scripts = sql.Split(new string[] { "GO" }, StringSplitOptions.None);
                    foreach (var splitScript in scripts)
                    {
                        command.CommandText = splitScript;
                        command.ExecuteNonQuery();
                    }
                }
            }
