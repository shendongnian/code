    public class Standard
    {
        string _title;
        ObservableCollection<string> _questions;        
    
        public string Title
        {
            get { return _title; }
            set { 
                _title = value;
                NotifyOfPropertyChanged(()=>Title);
            }
        }
    
        public ObservableCollection<string> Questions
        {
            get { return _questions; }
            set { 
                _questions = value;
                NotifyOfPropertyChanged(()=>Questions);
            }
        }
    }
    
    public class StandardViewModel
    {
        private ObservableCollection<Standard> _standardCollection;
        public ObservableCollection<Standard> StandardCollection{
            get
            {
                return _standardCollection;            
            }
            set{
                _standardCollection = value;
                NotifyOfPropertyChanged(()=>StandardCollection);
            }
        }
    }
