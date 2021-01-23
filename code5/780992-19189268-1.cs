    [CallbackBehavior(IncludeExceptionDetailInFaults = true,
        UseSynchronizationContext = true,
        ValidateMustUnderstand =true,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallbackClass : IDualMathServiceCallback
    {
        public delegate void ProceFinishedEventDelegate(string operation, double result);
        public event ProceFinishedEventDelegate ProcessFinishedEvent = null;
        public void ProcessingFinished(string operation, double result)
        {            
            if (ProcessFinishedEvent != null)
            {
                ProcessFinishedEvent(operation, result);
            }
        }
    }
