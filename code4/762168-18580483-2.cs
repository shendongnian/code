    public class ViewModel 
    {
        public List<string> StatusList { get; set; }
        // constructor
        public ViewModel()
        {
            StatusList = new List<string>();
            StatusList.Add("Hold");
            StatusList.Add("Send");
        }
    }
