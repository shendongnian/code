    // query method
    public void SomeQuery(SqlConnection connection)
    {
        ...
    }
    // use it
    using(SqlConnection aConnection=new SqlConnection('ConnectionString')  
    {
         aConnection.Open();
         otherClass.SomeQuery(aConnection);
    }   
