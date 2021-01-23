    public class HandleErrorInfo
    {   
        public HandleErrorInfo(Exception exception, string controllerName, 
            string actionName);
    
        public string ActionName { get; }
    
        public string ControllerName { get; }
    
        public Exception Exception { get; }
    }
