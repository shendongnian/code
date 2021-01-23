    private static void RegisterServices(IKernel kernel)  
    {
        kernel.Bind<ISiteConfiguration>().To<WebConfiguration>();
    }
    //Use this in your unit tests. Manually specify Setting1 as part of "Arrange" step in unit test. You can then use this to test the controller.
    public class TestConfiguration : ISiteConfiguration
    {
        public string Setting1 {get; set;}
    }
