    public class MainViewModel: INotifyPropertyChanged
    {
        private string uc_1;
        public string UC_1
        {
            get { return uc_1; }
            set
            {
                if (value == uc_1)
                    return;
                uc_1= value;
                OnPropertyChanged("UC_1");
            }
        }
        private string uc_2;
        public string UC_2
        {
            get { return uc_2; }
            set
            {
                if (value == uc_2)
                    return;
                uc_1= value;
                OnPropertyChanged("UC_2");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        //...
    }
 
