    namespace ClassLibrary1
    {
        public class Logger
        {
            public static string AssemblyGuid;
    
            public static void Init() {
                Assembly a = Assembly.GetCallingAssembly();
                var attribute = (GuidAttribute)a.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                AssemblyGuid = attribute.Value;
            }
        }
    }
