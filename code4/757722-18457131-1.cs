    public bool CheckUser(int mem_id)
    {
        bool flag = false;
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Id FROM Mem_Basic WHERE Id="+ mem_id +"", con))
            {
                con.Open();
                if (cmd.ExecuteScalar() != null
                {
                    flag = true;
                }
             }
          }
     }
