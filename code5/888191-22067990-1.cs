    static public DataTable SearchButton(string search)
        {
            using (var conn = new SqlConnection(DatabaseConnectionString))
            {
                var dt = new DataTable();
                const string searchQuery = "exec SearchTerm";
                using (var cmd = new SqlCommand(searchQuery, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Search_Term", SqlDbType.VarChar, search.Length).Value = "'%" + search + "%'";
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
        }
