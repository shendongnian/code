                String  ConnString = "Server=KEITH\\SQLEXPRESS;Database=Corset;Trusted_Connection=Yes";
                using (myConn = new SqlConnection(ConnString)) // This will make sure you actually close the DB
                {
                    myConn.Open(); // You need to open the connection
                    try
                    {
                        if (myConn.State == ConnectionState.Open)
                        {
                            dbWorks = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        dbWorks = false;
                    }
               }
