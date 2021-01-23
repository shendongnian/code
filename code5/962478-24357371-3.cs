    public class Incident : ObservableObject
    {
        private ObservableCollection<WordLetter> _start;
        public virtual ObservableCollection<WordLetter> Start
        {
            get { return _start; }
            set
            {
                if (value == _start) return;
                _start = value;
                NotifyPropertyChanged();
            }
        }
    }
