    class CustomerByIdQuery : IQuery, IQuery<int>
    {
      public int Id { get; set; }
    }
    class CustomerByIdQueryResult : IQueryResult, IQueryResult<Customer>
    {
      public Customer Customer {get; set;}
    }
