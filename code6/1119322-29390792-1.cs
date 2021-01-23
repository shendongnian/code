    public class ValidateDataInAPI
    {
        private static ILogger Logger
        {
            // DependencyResolver could be any DI container here.
            get { return DependencyResolver.Resolve<ILogger>(); }
        }
        public static bool IsValid(string data)
        {
            //do something
            If(error) 
            {
                Logger.Error("Log error as implemented by caller");
            }
        }
    }
