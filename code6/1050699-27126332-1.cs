    public class BaseController : Controller
    {
        public JsonResult ExecuteHandledJTableJsonOperation<T>(Func<JsonResult> actionToExecute, string errorMessage)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (Exception ex)
            {
                LogEntry entry = new LogEntry();
                entry.AddErrorMessage(ex.Message);
                entry.AddErrorMessage(String.Format("Inner Exception:", ex.InnerException.Message));
                //entry.Message = ex.Message;
                entry.Priority = 1;
                entry.EventId = 432;
                entry.Severity = System.Diagnostics.TraceEventType.Error;
                writer.Write(entry);
                return Json(new { Result = "ERROR", Message = errorMessage });
            }
        }
    }
