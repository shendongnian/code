    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
    {
       var newUrl = dbEntity.URLs.FirstOrDefault(url => url.StatusID == (int) URLStatus.New);
       if(newUrl != null)
       {
          newUrl.StatusID = (int) URLStatus.InProcess;
          dbEntity.SaveChanges();
       }
       scope.Complete();
    }
