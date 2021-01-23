    MySqlTransaction trans;
    try
    {
        using(var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using(trans = conn.BeginTransaction())
            {
                ......
                trans.Commit()
            }
        }
    }
    catch(MySqlException e)
    {
        // NOT NEEDED => gives error 
        // trans.Rollback();
    }
