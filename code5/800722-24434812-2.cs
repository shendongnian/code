    [TestClass]
    public class UnityConfigTests
    {
        private void SimulateRequestAndOwinContext(HttpSimulator simulator)
        {
            simulator.SimulateRequest();
            Dictionary<string, object> owinEnvironment = new Dictionary<string, object>()
                {
                    {"owin.RequestBody", null}
                };
            HttpContext.Current.Items.Add("owin.Environment", owinEnvironment);
        }
        [TestMethod]
        public void RegisterTypes_RegistersAllDependenciesOfHomeController()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            HomeController controller;
            using (HttpSimulator simulator = new HttpSimulator())
            {
                SimulateRequestAndOwinContext(simulator);
                controller = container.Resolve<HomeController>();
            }
            Assert.IsNotNull(controller);
        }
    }
