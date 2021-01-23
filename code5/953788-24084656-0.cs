       using (SqlConnection sqlcon = new SqlConnection(SQLConnectionStringGoesHere))
            {
                using (SqlCommand comm = new SqlCommand("STOREDPROCEDURENAME_Goes_Here", sqlcon))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comm))
                    {
                      
                        sqlcon.Open(); //Open the Connection and then begin a SQL Transaction 
                        using (SqlTransaction sqltran = sqlcon.BeginTransaction())
                        {
                            comm.Transaction = sqltran;   //begin tran      
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.Add("@OBJECTID", SqlDbType.NVarChar).Value = csvOfIds;
                            comm.Parameters.Add("@ANOTHERPARAMETER", SqlDbType.NVarChar).Value= "TEST";
                            int result = comm.ExecuteNonQuery(); //Execute Query
                            sqltran.Commit();//Commit SQL transaction
                            MessageBox.Show(string.Format("{0} Rows have been affected", result), "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information); //Show how many rows were affected
                        }
                    }
                }
            }
   
