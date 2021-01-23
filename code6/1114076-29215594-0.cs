    public static TSource ReadUncommittedAction<TSource>(Func<TSource> func)
    {
      var transactionOptions = new TransactionOptions()
      {
          IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
      };
      TSource outputItem;
      using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
      {
      	  outputItem = func();
          scope.Complete();
      }
      return outputItem;
    }
