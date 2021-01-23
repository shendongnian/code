        string SqlParallel = "";
        int OID = -1;
        Parallel.For(0, 100, i =>
        {
           using (NpgsqlConnection PGconnexion = new NpgsqlConnection(...))
    
           {
                SqlParallel = string.Format(@"INSERT INTO ParallelTest(Id) VALUES({0}) RETURNING OID;", i);
                using (NpgsqlCommand PGcommandParallel = new NpgsqlCommand(SqlParallel, PGconnexion))
                {
                     try { OID = (int)PGcommandParallel.ExecuteScalar(); }
                     catch (Exception ex) { Console.WriteLine(ex.Message); }
                 }
                 Console.WriteLine("Insert: {0} OID: {1}", i, OID);
             } 
         });
