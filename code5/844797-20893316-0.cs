    namespace ClassLibrary1
    {
        public class Class1
        {
            public static void MyMethod(CodeContext ctx, int number, string text)
            {
                var msg = string.Format("Warning: {0} and {1} ...", number, text);
                PythonWarnings.warn(ctx, msg, null, 0);
             }
        }
    }
