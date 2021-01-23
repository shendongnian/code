    [Route("url1/{id}")]
    public Book Get(int id){
       return new Book() { Title = "SQL Server 2012 id= " + id, Author = "Adrian " };
    }
           
    [Route("url1/{id}/{author}")]
    public Book Get(int id, string author){
       return new Book() { Title = "SQL Server 2012 id= " + id, Author = "Adrian & " + author };
    }
    ...
