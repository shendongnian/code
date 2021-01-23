    public class Test
    {
        private string _MyText;
        private IList<ComboBoxItem> _ComboList;
    
        public Test()
        {
            _MyText = "Test 123";
    
            _ComboList = new List<ComboBoxItem>();
    
            _ComboList.Add(new ComboBoxItem() { Content = "Next", IsSelected = true });
            _ComboList.Add(new ComboBoxItem() { Content = "Prev." });
        }
    
        public IList<ComboBoxItem> ComboList
        {
            get { return _ComboList; }
            set { _ComboList = value; }
        }
    
        public string MyText
        {
            get { return _MyText; }
            set { _MyText = value; }
        }
    }
