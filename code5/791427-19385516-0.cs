    using Company.WebServices;
    
    namespace ST_abcdef.csproj
    {
        [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
        public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
        {
            public void Main()
            {
                WebService1 webService1 = new WebService1();
                var result = webService1.methodA("param1", "param2");
                // process result
            }
        }
    }
