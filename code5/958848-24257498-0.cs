    class MyClass
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
        public static void DoSomething()
        {
            Log.Info( "Doing something" );
        }
    }
