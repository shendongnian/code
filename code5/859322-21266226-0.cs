            while (someStuff)            
            {
                MySqlTransaction trans;
                try
                {
                    trans = conn.BeginTransaction();
                    cmd.CommandText = getPersonUpdateString();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = getBookUpdateString();
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    writeError("", ex);
                    try
                    {
                       trans.Rollback();
                    }
                    catch (MySqlException)
                    {
                       writeError("", ex);
                    }
                }
            }
