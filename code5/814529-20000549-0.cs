    using (var conn = new MySqlConnection(PublicVariables.cs))
    {
        conn.Open();
        using(var tran = conn.BeginTransaction())
        {
            try
            {
                // ...command the first
                // ...command the second
                // ...command the third
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                ShowMessage(ex.Message); // etc
            }
        }
    }
