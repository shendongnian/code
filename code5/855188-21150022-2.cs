    [ComVisible(true)]
    public class ScriptObject
    {
        public void LongRunningProcess(string data, object callback)
        {
            string result = String.Empty;
    
            // do work, call the callback
    
            callback.GetType().InvokeMember(
                name: "[DispID=0]",
                invokeAttr: BindingFlags.Instance | BindingFlags.InvokeMethod,
                binder: null,
                target: callback,
                args: new Object[] { result });
        }
    }
