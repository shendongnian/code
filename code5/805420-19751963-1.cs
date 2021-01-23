    try
        {
            using (OleDbConnection con = new OleDbConnection(cs))
            {
                con.Open();
                OleDbTransaction tran = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand("UPDATE ... SET ... WHERE ...", con);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
            }
        }
        catch (OleDbException ex)
        {
            Console.WriteLine(ex);
        }
