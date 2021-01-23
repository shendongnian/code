    public interface ISiteConfiguration
    {
        string Setting1 {get; set;}
    }
    //Use this in your site. Pull configuration from external file
    public class WebConfiguration : ISiteConfiguration
    {
        public string Setting1 {get; set;}
        public WebConfiguration()
        {
            //Read info from external file here and store in Setting1
        }
    }
    //Use this in your unit tests. Manually specify Setting1 as part of "Arrange" step in unit test. You can then use this to test the controller.
    public class TestConfiguration : ISiteConfiguration
    {
        public string Setting1 {get; set;}
    }
