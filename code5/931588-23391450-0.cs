    public void EndTransaction()
        {
            mSqlTransaction.Commit();
            Close();
        }
