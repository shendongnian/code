    cmd.CommandText =
        @"INSERT INTO Companies (ID, CompanyName) VALUES (?, ?)";
    cmd.Parameters.Add("?", OleDbType.Integer);
    cmd.Parameters.Add("?", OleDbType.VarWChar, 255);
    cmd.Prepare();
    OleDbTransaction tran =  con.BeginTransaction();
    cmd.Transaction = tran;
    for (int i = 1; i <= 5000000; i++)
    {
        if ((i % 100) == 0)
        {
            Console.WriteLine(i.ToString());
        }
        cmd.Parameters[0].Value = i;
        cmd.Parameters[1].Value = "Company" + i.ToString();
        cmd.ExecuteNonQuery();
    }
    tran.Commit();
