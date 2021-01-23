    public class Executor
    {
        delegate void RunWhenFaild();
    
        void Execute(Action functionToBeExecuted, Action<Exception> callOnFailure)
        {
            RunWhenFaild += callOnFailure;
    
            try
            {
                functionToBeExecuted();
                RunWhenFaild -= callOnFailure;
            }
            catch (Exception e)
            {
                callOnFailure(e);
            }
        }
    }
