    public class Program
    {
        public static void Main (string[] args)
        {
            IProdistLogging logging = (IProdistLogging)System.Activator.CreateInstance(Type.GetTypeFromProgID("prodist.logging.Logging.5.4"));
            IProdistLoggingHierarchy hierarchy = logging.CreateHierarchy("log4cxx", null);
            return;
        }
    }
