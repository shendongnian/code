    public class Tab1ViewModel: MVVMTabItemViewModel
    {
        private string _text1;
        private string _text2;
        private bool _myBoolean;
        public Tab1ViewModel()
        {
            MyCommand = new Command(MyMethod);
        }
        public string Text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                OnPropertyChanged("Text1");
            }
        }
        public bool MyBoolean
        {
            get { return _myBoolean; }
            set
            {
                _myBoolean = value;
                MyCommand.IsEnabled = !value;
            }
        }
        public string Text2
        {
            get { return _text2; }
            set
            {
                _text2 = value;
                OnPropertyChanged("Text2");
            }
        }
        public Command MyCommand { get; set; }
        private void MyMethod()
        {
            Text1 = Text2;
        }
    }
