    public void FillDropDownList(Team.FRMAddTeam TeamAdd)
        {
            string PoolName = "";
            SqlConnection conn = GetConnection();
            string selStmt = "SELECT [Name] FROM dbo.TBL_pool";
            SqlCommand selCmd = new SqlCommand(selStmt, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = selCmd.ExecuteReader();
    
                while (reader.Read())
                {
                    PoolName = reader["Name"].ToString();
                    TeamAdd.addPoolItem(PoolName);
                }
            }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
            return;
        }
