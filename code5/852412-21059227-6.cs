    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase(string token)
        {
            Token = token;
        }
        protected string Token { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
