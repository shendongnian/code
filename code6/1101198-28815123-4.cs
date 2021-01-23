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
