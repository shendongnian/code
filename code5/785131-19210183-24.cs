    // this needs to be in the root namespace of your functional tests
    public class ServiceStackTestHostContext
    {
        [TestFixtureSetUp] // this method will run once before all other unit tests
        public void OnTestFixtureSetUp()
        {
            AppHost = new ServiceTestAppHost();
            AppHost.Init();
            AppHost.Start(ServiceTestAppHost.BaseUrl);
            // do any other setup. I have some code here to initialize a database context, etc.
        }
        [TestFixtureTearDown] // runs once after all other unit tests
        public void OnTestFixtureTearDown()
        {
            AppHost.Dispose();
        }
    }
