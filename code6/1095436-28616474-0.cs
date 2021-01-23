        protected void Page_Load(object sender, EventArgs e)
            {
            SqlConnection thisConnection = new SqlConnection("server=.;database=local;Integrated Security=SSPI");
            SqlCommand thisCommand = new SqlCommand("SELECT COUNT(*) FROM tbluser", thisConnection);
            try
                {
                thisConnection.Open();
                Console.WriteLine("Number of Employees is: {0}",
                   thisCommand.ExecuteScalar());
                }
            catch (SqlException ex)
                {
                Console.WriteLine(ex.ToString());
                }
            finally
                {
                thisConnection.Close();
                Console.WriteLine("Connection Closed.");
                }
            }
