    class CustomerByIdQuery : IQuery, IQuery<int, Customer>
    {
      public int Id { get; set; }
    }
    class CustomerByIdQueryResult : IQueryResult, IQueryResult<Customer>
    {
      public Customer Result {get; set;}
    }
