        public static string GetClassAndMethod() {
            string className = "", methodName = "";
            try {
                StackTrace st = new StackTrace(true);
                StackFrame sf = st.GetFrame(1);
                string filename = sf.GetFileName();
                className = filename.Substring(filename.LastIndexOf("\\") + 1);
                className = className.Substring(0, className.IndexOf("."));
                methodName = sf.GetMethod().Name;
            } catch (Exception ex) {
                className = "UnknownClass";
                methodName = "UnknownMethod";
            }
            return className + "." + methodName;      
      
        }
