    interface IQueryDispatcher
    {
        IQueryResult<TQueryResult> Dispatch<TQuery, TQueryResult>(IQuery<TQuery, TQueryResult> parms);
    }
    class GenericQueryDispatcher : IQueryDispatcher
    {
      public TQueryResult Dispatch<TQuery, TQueryResult>(IQuery<TQuery, TQueryResult> parms)
      {
        // TODO implement
      }
    }
