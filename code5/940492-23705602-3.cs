    namespace FrameworkAdapter {
    [ComVisible(true)]
    public class FwAdapter {
        private const String OK="OK";
        private const String frameworkEntryClassName = "${nameOfTheDllClass with method to run }";
        private const String log4netConfiguratorClassName = "log4net.Config.XmlConfigurator";
        private static Assembly frameworkDll = null;
        private static Type frameworkEntryClass = null;
        private static MethodInfo keywordRunMethod = null;
        private static Assembly logDll = null;
        private static Type logEntryClass = null;
        private static MethodInfo logConfigureMethod = null;
        private static String errorMessage = "OK";
        [RGiesecke.DllExport.DllExport]
        public static string loadAssemblies(string frameworkDllPath, string log4netDllPath) {
            try {
                errorMessage = LoadFrameworkDll(frameworkDllPath, frameworkEntryClassName);
                LoadFrameworkMethods("KeywordRun", "Setup", "TearDown");
                errorMessage = LoadLogAssembly(log4netDllPath, log4netConfiguratorClassName);
                if (errorMessage.CompareTo(OK) == 0)
                    errorMessage = LoadLogMethods("Configure");
            }
            catch (Exception e) {
                return e.Message;
            }
            return errorMessage;
        }
        
        [RGiesecke.DllExport.DllExport]
        public static string configureLog4net(string log4netConfigPath) {
            if (errorMessage.CompareTo("OK") == 0) {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Try to configure Log4Net");
                try {
                    FileInfo logConfig = new FileInfo(log4netConfigPath);
                    logConfigureMethod.Invoke(null, new object[] { logConfig });
                    sb.AppendLine("Log4Net configured");
                }
                catch (Exception e) {
                    sb.AppendLine(e.InnerException.Message);
                }
                return sb.ToString();
            }
            return errorMessage;
        }
        [RGiesecke.DllExport.DllExport]
        public static string runKeyword(string action, string xpath, string inputData, string verifyData) {
            StringBuilder sb = new StringBuilder();
            object result = null;
            try {
                result = keywordRunMethod.Invoke(null, new object[] { action, xpath, inputData, verifyData });
                sb.AppendLine(result.ToString());
            }
            catch (Exception e) {
                sb.AppendLine(e.InnerException.Message);
            }
            return sb.ToString();
        }
        private static String LoadFrameworkDll(String dllFolderPath, String entryClassName) {
            try {
                frameworkDll = Assembly.LoadFrom(dllFolderPath);
                Type[] dllTypes = frameworkDll.GetExportedTypes();
                foreach (Type t in dllTypes)
                    if (t.FullName.Equals(entryClassName)) {
                        frameworkEntryClass = t;
                        break;
                    }
            }
            catch (Exception e) {
                return e.InnerException.Message;
            }
            return OK;
        }
        private static String LoadLogAssembly(String dllFolderPath, String entryClassName) {
            try {
                logDll = Assembly.LoadFrom(dllFolderPath);
                Type[] dllTypes = logDll.GetExportedTypes();
                
                foreach (Type t in dllTypes)
                    if (t.FullName.Equals(entryClassName)) {
                        logEntryClass = t;
                        break;
                    }
            }
            catch (Exception e) {
                return e.InnerException.Message;
            }
            return OK;
        }
        private static String LoadLogMethods(String logMethodName) {
            try {
                logConfigureMethod = logEntryClass.GetMethod(logMethodName, new Type[] { typeof(FileInfo) });
            }
            catch (Exception e) {
                return e.Message;
            }
            return OK;
        }
        private static void LoadFrameworkMethods(String keywordRunName, String scenarioSetupName, String scenarioTearDownName) {
            ///TODO load the rest of the desired methods here
            keywordRunMethod = frameworkEntryClass.GetMethod(keywordRunName);
        }
    }
