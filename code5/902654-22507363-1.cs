    public class HandleErrorInfo
        {
            public string ActionName { get; set; }
            public string ControllerName { get; set; }
            public Exception Exception { get; set; }
            public HandleErrorInfo(Exception exception, string controllerName,
                string actionName)
            {
                this.ActionName = actionName;
                this.ControllerName = controllerName;
                this.Exception = exception;
            }
        }
