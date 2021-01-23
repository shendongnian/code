        using SqlConnection con = new SqlConnection(connString))
        {
            using(SqlCommand cmd = new SqlCommand("Select * from Student", con))
            {
                ....
            }
        }
