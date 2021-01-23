    public partial class MainPage : Page, INotifyPropertyChanged
    #region INotifyPorpertyChanged Memebers 
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    #endregion
