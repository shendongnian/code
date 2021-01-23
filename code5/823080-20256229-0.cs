        public interface IQueryDispatcher
      {
        TQueryResult Dispatch<TParameter, TQueryResult>(IQuery<TQueryResult> query)
          where TParameter : IQuery<TQueryResult>
          where TQueryResult : IQueryResult;
      }
      public interface IQueryHandler<in TQuery, out TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
      {
        TQueryResult Retrieve(TQuery query);
      }
    
    
      public interface IQueryResult { }
    
      
    
      public interface IQuery { }
      public interface IQuery<TQueryResult> : IQuery { }
    
    
      public class QueryDispatcher : IQueryDispatcher
      {
        readonly IQueryHandlerRegistry _queryRegistry;
    
        public QueryDispatcher(IQueryHandlerRegistry queryRegistry)
        {
          _queryRegistry = queryRegistry;
        }
    
        public TQueryResult Dispatch<TQuery, TQueryResult>(IQuery<TQueryResult> query)
          where TQuery : IQuery<TQueryResult>
          where TQueryResult : IQueryResult
        {
          var handler = _queryRegistry.FindQueryHandlerFor<TQuery, TQueryResult>(query);
    
           //CANT GET RID OF CAST
          return handler.Retrieve((TQuery)query);
        }
      }
    
      public interface IQueryHandlerRegistry
      {
        IQueryHandler<TQuery, TQueryResult> FindQueryHandlerFor<TQuery, TQueryResult>(IQuery<TQueryResult> query) 
          where TQuery : IQuery<TQueryResult> 
          where TQueryResult : IQueryResult;
      }
    
      public class GetCustByIdAndLocQuery : IQuery<CustByIdAndLocQueryResult>
      {
        public string CustName { get; set; }
        public int LocationId { get; set; }
    
        public GetCustByIdAndLocQuery(string name, int locationId)
        {
          CustName = name;
          LocationId = locationId;
        }
      }
    
      public class CustByIdAndLocQueryResult : IQueryResult
      {
        public Customer Customer { get; set; }
      }
    
      public class GetCustByIdAndLocQueryHandler : IQueryHandler<GetCustByIdAndLocQuery, CustByIdAndLocQueryResult>
      {
        readonly ICustomerGateway _customerGateway;
    
        public GetCustByIdAndLocQueryHandler(ICustomerGateway customerGateway)
        {
          _customerGateway = customerGateway;
        }
    
        public CustByIdAndLocQueryResult Retrieve(GetCustByIdAndLocQuery query)
        {
          var customer = _customerGateway.GetAll()
                            .SingleOrDefault(x => x.LocationId == query.LocationId && x.CustomerName == query.CustName);
    
          return new CustByIdAndLocQueryResult() { Customer = customer };
        }
      }
    
      public interface ICustomerGateway
      {
        IEnumerable<Customer> GetAll();
      }
    
      public class Customer
      {
        public string CustomerName { get; set; }
        public int LocationId { get; set; }
    
        public bool HasInsurance { get; set; }
      }
