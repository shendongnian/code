    public static void processline()
    {
        Interlocked.Increment(ref counter);
        sql.ExecuteNonQuery();
        Interlocked.Decrement(ref counter);
    }
