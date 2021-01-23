        public static void Init()
        {
            Test.Initialize(
                x =>
                {
                    x.Conventions().DefiningCommandsAs(x => x.Namespace.Contains("Commands"));
                    x.Conventions().DefiningEventsAs(x => x.Namespace.Contains("Events"));
                    x.AssembliesToScan(GetAssembliesToScan());
                });
        }
        private static IEnumerable<Assembly> GetAssembliesToScan()
        {
            return new[]
            {
                AssemblyFromType<ISomeInterface>(),
                Assembly.LoadFrom("NServiceBus.Testing.dll")
            };
        }
