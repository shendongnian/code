    public class xxViewModel
    {
        public string a { get; set; }
        public string b{ get; set; }
        public string c{ get; set; }
        public string d{ get; set; }
    }
    public class MainViewModel
    {
        public string Message { get; set; }
        public IEnumerable<xxViewModel> Elements { get; set; }
    }
