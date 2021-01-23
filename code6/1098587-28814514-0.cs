    private static void TestPreparedStatement()
    {
        const string sql = "INSERT INTO myTable(id, numInt) " +
                           "VALUES((SELECT MAX(id) " +
                                   "FROM myTable) + 1, @numInt);";
        using (SqlConnection dbConn = new SqlConnection(s_connStr))
        {
            dbConn.Open();
            Console.WriteLine("Getting ready to prepare statement on connection with ID " + dbConn.ClientConnectionId);
            s_cmd = new SqlCommand(sql, dbConn);
            s_cmd.Parameters.Add("@numInt", SqlDbType.Int);
            s_cmd.Prepare();
            Console.WriteLine("The command has been prepared.");
        }
        for (int threadNdx = 0; threadNdx < 10; ++threadNdx)
        {
            Thread prepStmntThread = new Thread(ExecPrepStmnt)
            {
                Name = threadNdx.ToString()
            };
            prepStmntThread.Start();
        }
    }
    private static void ExecPrepStmnt()
    {
        using (SqlConnection dbConn = new SqlConnection(s_connStr))
        {
            dbConn.Open();
            lock (s_cmd)
            {
                Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " has ownership of the command.");
                s_cmd.Connection = dbConn;
                s_cmd.Parameters["@numInt"].Value = int.Parse(Thread.CurrentThread.Name);
                Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " is about to execute the command on the connection with ID " + s_cmd.Connection.ClientConnectionId + ".");
                try
                {
                    s_cmd.ExecuteNonQuery();
                    Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " successfully executed the command.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " failed to execute the command.");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " is about to relinquish ownership of the command.");
            }
            Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " is going to sleep with open pooled connection.");
            Thread.Sleep(5 * 1000);
        }
        Console.WriteLine("Thread #" + Thread.CurrentThread.Name + " has woken up and disposed of its pooled connection.");
    }
