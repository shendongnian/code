    // implmeent INotifyPropertyChanged
    public class TextBoxPlaceholder : IDataErrorInfo, System.ComponentModel.INotifyPropertyChanged
    {
        private string mValue;
        public string Value 
        {
            get{ return mValue; }
            // fire notification
            set{mValue = value;NotifyPropertyChanged("Value");}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // helper method
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        // your code goes here
