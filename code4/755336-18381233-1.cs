     protected void Application_Error(Object sender, System.EventArgs e)
            {
                System.Web.HttpContext context = HttpContext.Current;
                System.Exception exception = Context.Server.GetLastError();
                var stackTraceExcep = new StackTrace(exception, true); 
                var stackTrace = stackTraceExcep.GetFrames()         
                              .Select(frame => new
                              {                   // get the info
                                  FileName = frame.GetFileName(),
                                  LineNumber = frame.GetFileLineNumber(),
                                  ColumnNumber = frame.GetFileColumnNumber(),
                                  Method = frame.GetMethod(),
                                  Class = frame.GetMethod().DeclaringType,
                              }).FirstOrDefault();
    
    
                **string FileName = !string.IsNullOrEmpty(stackTrace.FileName) ? Server.UrlEncode(stackTrace.FileName) : "";**
                string LineNumber = stackTrace.LineNumber.ToString();
                string ColumnNumber = stackTrace.ColumnNumber.ToString();
                string MethodName = stackTrace.Method.Name;
                string ClassName = stackTrace.Class.Name;
                if (!string.IsNullOrEmpty(exception.Message))
                {
                    Response.Redirect(String.Format("~/Error/{0}/?errorMessage={1}&fileName={2}&lineNumber={3}&columnNumber={4}&methodName={5}&className={6}", "App_Error", exception.Message, FileName, LineNumber, ColumnNumber, MethodName, ClassName));
       
                }
                context.Server.ClearError();
            }
