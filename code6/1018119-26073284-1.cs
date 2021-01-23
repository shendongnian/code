    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string textBoxValue;
        public string TextBoxValue
        {
            get { return textBoxValue; }
            set
            {
                textBoxValue = value;
                OnTextBoxValueChanged();
                RaisePropertyChanged();
            }
        }
        void OnTextBoxValueChanged()
        {
            // you logic here, if needed.
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
