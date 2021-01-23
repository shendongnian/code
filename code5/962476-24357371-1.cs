    public class Word : ObservableObject
    {
        private ObservableCollection<WordLetter> _start;
        public virtual ObservableCollection<WordLetter> Letters
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
