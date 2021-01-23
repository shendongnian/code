    public class ViewModel
    {
        private string _firstText;
        public string FirstText 
        {
            get  {return _firstText; } 
            set { _firstText = value; RaisePropertyChanged("FirstAndSecondText"); }
        }
        private string _secondText;
        public string SecondTExt
        {
            get  {return _secondText; } 
            set { _secondText= value; RaisePropertyChanged("FirstAndSecondText"); }
        }
        public string FirstAndSecondText {get {return FirstText + SecondText; }}
    }
