    public class NotifyOnPropertyChanged : INotifyPropertyChanged
    {
        private IDictionary<string, PropertyChangedEventArgs> _arguments;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if(_arguments == null)
            {
                _arguments = new Dictionary<string, PropertyChangedEventArgs>();
            }
            if(!_arguments.ContainsKey(property))
            {
                _arguments.Add(property, new PropertyChangedEventArgs(property));
            }
            PropertyChanged(this, _arguments[property]);
        }
    }
