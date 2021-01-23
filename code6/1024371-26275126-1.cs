    void DoStuffWithEF(SqlConnection connection)
    {
        using(var context=new MyCodeFirstDbContext(connection,false)
        {
        // ...
        }
    }
