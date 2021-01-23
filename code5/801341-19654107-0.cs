    using (StreamReader reader = File.OpenText("somefile.txt")) {
        //Use a transaction: you should do bulk inserts inside transactions
        DbTransaction tr = sqlite_conn.BeginTransaction();
        //Create a command once.
        DbCommand cmd = sqlite_conn.CreateCommand();
        //Assign SQL with parameters (?)
        cmd.CommandText = "INSERT INTO test (id, text) VALUES (?, ?);"
        string line;
        int line_num=0;
        //Read all lines from file
        for (line_num=0; line = reader.ReadLine() != null; ++line_num) {
            //For each line, assign correct parameters
            cmd.Parameters(0).Value=line_num;
            cmd.Parameters(1).Value=line;
            //Send command to database
            cmd.ExecuteNonQuery();
        }
        //Commit - only at this point data is written to database
        tr.Commit();
    }
