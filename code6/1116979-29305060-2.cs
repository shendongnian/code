    private static DataTable GetData(string flagType)
            {
                using (SqlConnection con = new SqlConnection("..."))
                {
    
                    string myQuery = "SELECT MESSAGE FROM MYTABLE WHERE Flag = " + flagType + " ORDER BY CREATEDATE DESC";
                    using (SqlCommand cmd = new SqlCommand(myQuery, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            con.Open();
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
    
            private static DataTable GetFlags()
            {
                using (SqlConnection con = new SqlConnection("..."))
                {
    
                    string myQuery = "SELECT DISTINCT Flag FROM MYTABLE";
                    using (SqlCommand cmd = new SqlCommand(myQuery, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            con.Open();
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
