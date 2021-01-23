    public static class StackHelper
    {
        public static string GetCurrentPropertyName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            MethodBase currentMethodName = sf.GetMethod();
            return currentMethodName.Name.Replace("get_", "");
        }
    }
