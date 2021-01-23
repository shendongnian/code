    public static class HttpSimulatorExtensions
    {
        public static void SimulateRequestAndOwinContext(this HttpSimulator simulator)
        {
            simulator.SimulateRequest();
            Dictionary<string, object> owinEnvironment = new Dictionary<string, object>()
                {
                    {"owin.RequestBody", null}
                };
            HttpContext.Current.Items.Add("owin.Environment", owinEnvironment);
        }        
    }
    [TestClass]
    public class UnityConfigTests
    {
        [TestMethod]
        public void RegisterTypes_RegistersAllDependenciesOfHomeController()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            HomeController controller;
            using (HttpSimulator simulator = new HttpSimulator())
            {
                simulator.SimulateRequestAndOwinContext();
                controller = container.Resolve<HomeController>();
            }
            Assert.IsNotNull(controller);
        }
    }
