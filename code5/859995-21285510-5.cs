    using(var txn = new MyTransaction()) {
      txn.Register(() => ftpManager.CreateUserAccount(user),
                   () => ftpManager.DeleteUserAccount(user));
      txn.Register(() => ftpManager.CreateUserFolder(user, folder),
                   () => ftpManager.DeleteUserFolder(user, folder));
      /* ... */
      txn.Commit();
    }
    
    class MyTransaction : IDisposable {
      public void Register(Action operation, Action undoOperation){ /**/ }
      public void Commit(){ /* Runs all registered operations */ }
      public void Dispose(){ /* Executes undo for all registered and attempted operations */ }
    }
