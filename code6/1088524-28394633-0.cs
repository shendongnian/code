    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            DoBadThings();
        }
        private static void DoBadThings()
        {
            DoOneLevelBelow();
        }
        private static void DoOneLevelBelow()
        {
           
            for(int i=0;i<10;i++)
            {
                try
                {
                    if (i == 5)
                    {
                        var invalidCast = (string)((object)i);
                    }
                    else
                    {
                        throw new InvalidTimeZoneException();
                    }
                }
                catch
                {
                }
            }
        }
        static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            if( e.Exception is InvalidCastException)
            {
                LogInvalidCast((InvalidCastException)e.Exception);
            }
        }
        private static void LogInvalidCast(InvalidCastException invalidCastException)
        {
            Console.WriteLine("Got Invalid cast: {0}", invalidCastException);
        }
