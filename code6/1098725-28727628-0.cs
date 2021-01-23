    public class Data
    {
        public Data()
        {
            List = new ObservableCollection<string>
            {
                "Apple", "Orange", "Lime"
            };
        }
        public ObservableCollection<string> List { get; private set; }
        public string Selected { get; set; }
    }
