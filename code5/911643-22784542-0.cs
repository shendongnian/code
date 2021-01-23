        static void Main(string[] args)
        {
            decimal d = 34.09090909090909M;
            Console.WriteLine(d);
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.IntegratedSecurity = true;
            scsb.DataSource = @".\sql2012";
            using (SqlConnection conn = new SqlConnection(scsb.ConnectionString)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                   "select cast(@d as DECIMAL(20,15))", conn))
                {
                    cmd.Parameters.AddWithValue("@d", d);
                    decimal rd = (decimal) cmd.ExecuteScalar();
                    Console.WriteLine(rd);
                }
            }
        }
