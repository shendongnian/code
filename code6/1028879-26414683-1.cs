// usage
GuardedOperation TheGuard = new GuardedOperation() // instance variable
public void SomeOperationToGuard()
{
   this.TheGuard.Execute(() => TheCodeToExecuteGuarded);
}
    // implementation
    public class GuardedOperation
    {
        public bool Signalled { get; private set; }
        
        public bool Execute(Action guardedAction)
        {
            if (this.Signalled)
                return false;
            this.Signalled = true;
            try
            {
                guardedAction();
            }
            finally
            {
                this.Signalled = false;
            }
            return true;
        }
    }
