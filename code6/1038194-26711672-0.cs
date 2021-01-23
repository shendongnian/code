            SqlConnection conn = new SqlConnection(connectionString);
            List<User> oracleList = new List<User>();
            string cmd = "SELECT name,surname FROM users";
            DataSet ds = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd, conn);
            try
            {
                conn.Open();
                dAdapter.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    User user =new User();
                    user.name=ds.Tables[0].Rows[i]["name"];
                    user.surname=ds.Tables[0].Rows[i]["surname"];
                    oracleList.add(user);
                }
            }
            
            catch (Exception ex)
            {
                //do something
            }
            finally
            {
                conn.Close();
            }
