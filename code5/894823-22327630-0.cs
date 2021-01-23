            Parallel.For(0, 100, i =>
            {
                string SqlParallel = string.Format(@"INSERT INTO ParallelTest(Id) VALUES({0}) RETURNING OID;", i);
                using (NpgsqlConnection PGconnexionParallel = new NpgsqlConnection(string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", PGHost, PGPort, PGUser, PGPassword, PGDatabase)))
                {
                    PGconnexionParallel.Open();
                    using (NpgsqlCommand PGcommandParallel = new NpgsqlCommand(SqlParallel, PGconnexionParallel))
                    {
                        try 
                        { 
                            int OID = (int)PGcommandParallel.ExecuteScalar();
                            Console.WriteLine("SqlParallel: {0} OID: {1}", SqlParallel, OID);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
            }); 
