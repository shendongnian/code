    public bool CheckUser(int mem_id)
    {
        bool flag = false;
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Mem_Basic WHERE Id="+ mem_id +""", con))
            {
                con.Open();
                int count = (int) cmd.ExecuteScalar();
                if(count > 0)
                {
                    flag = true;
                }
            }
        }
        return flag;
    }
