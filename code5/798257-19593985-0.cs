    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=TestDb;Trusted_Connection=True;"))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var cmd = new SqlCommand("INSERT INTO TESTTABLE (test) values ('" + DateTime.Now.ToString() + "')", conn))
                    {
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                    }
                    using (var tran2 = conn.BeginTransaction())    // <-- EXCEPTION HERE
                    {
                        using (var cmd = new SqlCommand("INSERT INTO TESTTABLE (test) values ('INSIDE" + DateTime.Now.ToString() + "')", conn))
                        {
                            cmd.Transaction = tran2;
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    tran.Commit();
                }
            }
        }
    }
