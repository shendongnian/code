    public ObservableCollection<RefreshLog> GetRefreshLog()
    {
    
       using (var scope = new TransactionScope(TransactionScopeOption.Required,
                 new TransactionOptions() {
                     IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                 }))
       {
          ObservableCollection<RefreshLog> obs;
    
          using (var db = new HiggidyPiesEntities())
          {
             var recs =
                  (from x in db.RefreshLogs orderby x.LG_ID descending select x).Take(30);
             obs = new ObservableCollection<RefreshLog>(recs);
          }
    
          scope.Complete();
          return obs;
       }
    
    }
