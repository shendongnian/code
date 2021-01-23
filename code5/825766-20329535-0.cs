    public class Test
    {
        public static string Tester()
        {
            try
            {
                 //SOMETHING
            } 
            catch (Exception exception)
            {
                Log(exception);
            }
        }
        public static void Log(Exception exception)
        {
               var namespace = new StackFrame(1).GetMethod().DeclaringType.Namespace;
               //MOREOFSOMETHING
        }
    }  
