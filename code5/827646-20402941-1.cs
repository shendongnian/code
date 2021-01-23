    public class Service1 : IService1
    {
        private ISessionInspector _sessionInspector; //will access OperationContext.Current
        public Service1(ISessionInspector sessionInspector)
        {
            _sessionInspector = sessionInspector;
        }
        public string GetData(int value)
        {
            var sessionId = _sessionInspector.GetCurrentSessionID();
            ...
        }
