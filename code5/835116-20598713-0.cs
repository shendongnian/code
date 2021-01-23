    [TestFixture]
    public class MvvmCrossTestSetup
    {
        private IMvxIoCProvider _ioc;
        protected IMvxIoCProvider Ioc
        {
            get { return _ioc; }
        }
        public void Setup()
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            // fake set up of the IoC
            MvxSingleton.ClearAllSingletons();
            _ioc = MvxSimpleIoCContainer.Initialise();
            _ioc.RegisterSingleton(_ioc);
            _ioc.RegisterSingleton<IMvxTrace>(new TestTrace());
            RegisterAdditionalSingletons();
            InitialiseSingletonCache();
            InitialiseMvxSettings();
            MvxTrace.Initialize();
        }
        protected void InitialiseMvxSettings()
        {
            _ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
        }
        protected virtual void RegisterAdditionalSingletons()
        {
        }
        private static void InitialiseSingletonCache()
        {
            MvxSingletonCache.Initialise();
        }
        [Test]
        public void GetTemp()
        {
            Setup();
            var temp = Path.GetTempPath();
            MvxTrace.Trace("hello from Mvx");
            Trace.WriteLine("hello from Trace");
            Debug.WriteLine("hello from Debug");
            Assert.NotNull(temp);
        }
        private class TestTrace : IMvxTrace
        {
            public void Trace(MvxTraceLevel level, string tag, Func<string> message)
            {
                Debug.WriteLine(tag + ":" + level + ":" + message());
            }
            public void Trace(MvxTraceLevel level, string tag, string message)
            {
                Debug.WriteLine(tag + ": " + level + ": " + message);
            }
            public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
            {
                Debug.WriteLine(tag + ": " + level + ": " + message, args);
            }
        }
    }
