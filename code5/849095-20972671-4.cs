    public abstract class AbstractFileSave : IEnlistmentNotification {
      protected AbstractFileSave(string filePath) {
        FilePath = filePath;
      }
      
      public string FilePath { get; private set; }
      
      public void Prepare(PreparingEnlistment preparingEnlistment) {
        try {
          var success = OnSaveFile(FilePath);
          if (success) {
            // Console.WriteLine("[Prepared] {0}", FilePath);
            preparingEnlistment.Prepared();
          }
          else {
            throw new Exception("Error saving file");
          }
        }
        catch (Exception ex) {
          // we vote to rollback, so clean-up must be done manually here
          OnDeleteFile(FilePath);
          preparingEnlistment.ForceRollback(ex);
        }
      }
      
      public void Commit(Enlistment enlistment) {
        // Console.WriteLine("[Commit] {0}", FilePath);
        enlistment.Done();
      }
      
      public void Rollback(Enlistment enlistment) {
        // Console.WriteLine("[Rollback] {0}", FilePath);
        OnDeleteFile(FilePath);
        enlistment.Done();
      }
      
      public void InDoubt(Enlistment enlistment) {
        // in doubt operation here
        enlistment.Done();
      }
      
      // for manual clean up
      public void CleanUp() {
        // Console.WriteLine("[Manual CleanUp] {0}", FilePath);
        OnDeleteFile(FilePath);
      }
      protected abstract bool OnSaveFile(string filePath);
      
      protected virtual void OnDeleteFile(string filePath) {
        if (File.Exists(FilePath)) {
          File.Delete(FilePath);
        }
      }
    }
