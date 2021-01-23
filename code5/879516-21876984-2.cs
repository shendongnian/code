    public class ViewModel : INotifyPropertyChanged
    {
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; OnPropertyChanged("Comment"); }
        }
    
        public GenericRelayCommand<string> SubmitComment1Command { get; set; }
        public RelayCommand SubmitComment2Command { get; set; }
    
        public ViewModel()
        {
            Comment = "Hello World!";
            SubmitComment1Command = new GenericRelayCommand<string>(OnSubmitComment1);
            SubmitComment2Command = new RelayCommand(OnSubmitComment2);
        }
    
        private void OnSubmitComment1(string obj)
        {
            //Save Comment Mock with CommandParameter
            MessageBox.Show(obj);    
        }
    
        private void OnSubmitComment2(object obj)
        {
            //Save Comment Mock with Property
            MessageBox.Show(Comment);
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
