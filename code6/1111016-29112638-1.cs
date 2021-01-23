    [OnTransaction]
    public void IncreasePay()
    {
        Pay++;
    }
    
    [Serializable]
    public class OnTransactionAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Log(DateTime.Now); // or other way such as StopWatch, whatever ...
        }
    }
