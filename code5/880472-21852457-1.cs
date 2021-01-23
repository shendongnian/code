    var sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    OleDbConnection con = new OleDbConnection();
    string dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;";
    string dbSource = "Data Source = C:/Users/Gord/Desktop/speed.mdb";
    con.ConnectionString = dbProvider + dbSource;
    con.Open();
    OleDbCommand cmd = new OleDbCommand();
    cmd.Connection = con;
    cmd.CommandText = "INSERT INTO tblBooks (Title, Price, Tag, Author) VALUES (?,?,?,?)";
    cmd.Parameters.Add("?", OleDbType.VarWChar, 255);
    cmd.Parameters.Add("?", OleDbType.Currency);
    cmd.Parameters.Add("?", OleDbType.VarWChar, 255);
    cmd.Parameters.Add("?", OleDbType.VarWChar, 255);
    cmd.Prepare();
    cmd.Parameters[0].Value = "Dummy Text 1";
    cmd.Parameters[1].Value = 10;
    cmd.Parameters[2].Value = "Dummy Text 2";
    cmd.Parameters[3].Value = "Dummy Text 3";
    OleDbTransaction trn = con.BeginTransaction();
    cmd.Transaction = trn;
    for (int i = 0; i < 100000; i++)
    {
        cmd.ExecuteNonQuery();
    }
    trn.Commit();
    con.Close();
    sw.Stop();
    Console.WriteLine(String.Format("{0:0.0} seconds", sw.ElapsedMilliseconds / 1000.0));
