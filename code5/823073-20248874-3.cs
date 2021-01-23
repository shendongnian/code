    interface IQueryDispatcher
    {
        IQueryResult<TQueryResult> Dispatch<TQuery, TQueryResult>(IQuery<TQuery> parms);
    }
    class GenericQueryDispatcher : IQueryDispatcher
    {
      public TQueryResult Dispatch<TQuery, TQueryResult>(IQuery<TQuery> parms)
      {
        // TODO implement
      }
    }
