    namespace ConsoleApplication2
    {
    class Program
    {
        static void Main(string[] args)
        {
            MefInitilizer.Run();
            Debug.Write(AnotherClass.Test);
        }
    }
    public class AnotherClass
    {
        static AnotherClass()
        {
        }
        public static String Test = ContainerSingleton.ContainerInstance;
    }
    public static class MefInitilizer
    {
        static MefInitilizer()
        {
        }
        public static void Run()
        {
            ContainerSingleton.Initialize("A string");
        }
    }
    public class ContainerSingleton
    {
        static ContainerSingleton()
        {
        }
        private static String compositionContainer;
        public static String ContainerInstance
        {
            get
            {
                if (compositionContainer != null) return compositionContainer;
                var appDomainName = AppDomain.CurrentDomain.FriendlyName;
                throw new Exception("Composition container is null and must be initialized through the ContainerSingleton.Initialize()" + appDomainName);
            }
        }
        public static void Initialize(String container)
        {
            compositionContainer = container;
        }
    }
     }
