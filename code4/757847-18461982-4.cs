    public class MainModel
    {
        public MainModel() { OtherViewModel = new OtherViewModel(); }
        public OtherViewModel OtherViewModel { get; set; }        
    }
    public class OtherViewModel
    {
        public OtherViewModel() { ViewModel = new ViewModel(); }
        public ViewModel ViewModel { get; set; }
    }
    public class ViewModel
    {
        public string Object { get; set; }
    }
