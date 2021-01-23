    [ComVisible(true)]
    public class ScriptObject
    {
        public void LongRunningProcess(string data, object callback)
        {
            string result = String.Empty;
    
            // do work, call the callback
    
            dynamic callbackMethod = callback;
            callbackMethod(result);
        }
    }
