    public class StatusBarViewModel : INotifyPropertyChanged
    {
        private string message = string.Empty;
        public string Message
        {
            get { return message; }
            set
            {
                if (value == message) return;
                message = value;
                OnPropertyChanged();
            }
        }
        public async Task ShowMessageAndHide(string message)
        {
            Message = message;
            await Task.Delay(5000);
            Message = string.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
