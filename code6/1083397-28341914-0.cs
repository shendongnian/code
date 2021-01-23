    using (connectionDb)
    {
        connectionDb.Open();
        using (var ts = new System.Transactions.TransactionScope())
        {
            try
            {
                File.Copy(sourceFileName, destFileName, overwrite);
                connectionDb.ExecuteNonQuery();
                ts.Complete();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { }
        }
    }
