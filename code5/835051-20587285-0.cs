    public class Credits
    {
        public int availableCredits { get; set; }
        public string total { get; set; }
        public string used { get; set; }
    }
    
    public class AjaxResponse
    {
        public Credits credits { get; set; }
        public int success { get; set; }
    }
    
    public class Root
    {
        public AjaxResponse ajaxResponse { get; set; }
    }
    
    public class RootObject
    {
        public Root root { get; set; }
    }
