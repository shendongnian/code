    public class GameStateViewModel : INotifyPropertyChanged
    {
        private int currentScore = 10;
        /// <summary>
        /// The timer here added to simulate whatever is supposed to be changing your value. 
        /// </summary>
        public GameStateViewModel()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            timer.Tick += (sender, args) =>
            {
                if (this.CurrentScore > 0)
                {
                    this.CurrentScore--;
                }
                else
                {
                    timer.Stop();
                }
            };
            timer.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int CurrentScore
        {
            get { return currentScore; }
            set
            {
                currentScore = value;
                NotifyPropertyChanged("CurrentScore");
            }
        }
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
