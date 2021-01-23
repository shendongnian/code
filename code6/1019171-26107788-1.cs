        public object Execute(byte[] assemblyBytes)
        {
            AppDomain domainWithAsm = AsmLoad.Execute(assemblyBytes);
            ....
        }
        [Serializable]
        public class AsmLoad
        {
            public byte[] AsmData;
            public void LoadAsm() 
            {
                Assembly.Load(AsmData);
                Console.WriteLine("Loaded into: " + AppDomain.CurrentDomain.FriendlyName);
            }
            public static AppDomain Execute(byte[] assemblyBytes)
            {
                AsmLoad asmLoad = new AsmLoad() { AsmData = assemblyBytes };
                var app = AppDomain.CreateDomain("MonitoringProxy", AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = AppDomain.CurrentDomain.BaseDirectory }, new PermissionSet(PermissionState.Unrestricted));
                app.DoCallBack(new CrossAppDomainDelegate(asmLoad.LoadAsm));
                return app;
            }
        }
