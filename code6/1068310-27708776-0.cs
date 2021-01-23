        public class Game : INotifyPropertyChanged
        {
            private int _rating;
            // Declare the event 
            public event PropertyChangedEventHandler PropertyChanged;
            public Game()
            {
            }
            public Game(int value)
            {
                _rating = value;
            }
            public int Rating
            {
                get { return _rating; }
                set
                {
                    _rating = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged("Rating");
                }
            }
            // Create the OnPropertyChanged method to raise the event 
            protected void OnPropertyChanged(string name)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
