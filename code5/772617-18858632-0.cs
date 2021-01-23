    public class OtherViewModel()
    {
        public OtherViewModel(Some some, MySettings mySettings)
        {
            Some = some;
            MySettings = mySettings;
        }
    
        public Some Some { get; set; }
        public MySettings Settings { get; set; }
    }
