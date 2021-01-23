    using(var txn = new MyTransaction()) {
      txn.RegisterCommand(new CreateUserFtpAccountCommand());
      txn.RegisterCommand(new CreateUserFolderCommand());
      txn.RegisterCommand(new SetUserPermissionCommand());
      txn.RegisterCommand(new CreateVirtualDirectoryForUserCommand());
      txn.Commit();
    }
    class MyTransaction : IDisposable {
      public void RegisterCommand(Command command){ /**/ }
      public void Commit(){ /* Runs all registered commands */ }
      public void Dispose(){ /* Executes undo for all registered commands */ }
    }
    class UndoableCommand {
      public Command(Action action) { /**/ }
      public void Execute() { /**/ }
      public void Undo{ /**/ }
    }
