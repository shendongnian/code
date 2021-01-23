    public class PageViewModel : INotifyPropertyChanged
    {
        ...
        public int CommandGroup
        {
            get { return _commandGroup; }
            set { _commandGroup = value; NotifyPropertyChanged("CommandGroup"); }
        }
    }
