        public SqlConnection myConnection = new SqlConnection("");
        public DataTable Select(string sTSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sTSQL,  myConnection);
                myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                dt = null;
            }
            finally
            {
                try
                {
                    myConnection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return dt;
        }     
