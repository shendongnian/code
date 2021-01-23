    public class TimeBehavior : INotifyPropertyChanged
    {
        // Global instance
        private static TimeBehavior _instance = new TimeBehavior();
        public static TimeBehavior Instance
        {
            get
            {
                return _instance;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _currentTime = DateTime.Now.ToString("HH:mm");
        public string CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CurrentTime"));
                    }
                }
            }
        }
        private string _currentDayString = ReturnDayString();
        public string CurrentDayString
        {
            get
            {
                return _currentDayString;
            }
            set
            {
                if (_currentDayString != value)
                {
                    _currentDayString = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CurrentDayString"));
                    }
                }
            }
        }
        private string _currentMonthAndDayNumber = ReturnMonthAndDayNumber();
        public string CurrentMonthAndDayNumber
        {
            get
            {
                return _currentMonthAndDayNumber;
            }
            set
            {
                if (_currentMonthAndDayNumber != value)
                {
                    _currentMonthAndDayNumber = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CurrentMonthAndDayNumber"));
                    }
                }
            }
        }
        public static readonly DependencyProperty IsTimerStartProperty;
        public static void SetIsTimerStart(DependencyObject DepObject, bool value)
        {
            DepObject.SetValue(IsTimerStartProperty, value);
        }
        public static bool GetIsTimerStart(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsTimerStartProperty);
        }
        static void OnIsTimerStartPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && ((bool)e.NewValue) == true)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
        }
        static TimeBehavior() 
        {
            IsTimerStartProperty = DependencyProperty.RegisterAttached("IsTimerStart",
                                                                    typeof(bool),
                                                                    typeof(TimeBehavior),
                                                                    new PropertyMetadata(new PropertyChangedCallback(OnIsTimerStartPropertyChanged)));
        }
        private static void timer_Tick(object sender, EventArgs e)
        {
            _instance.CurrentTime = DateTime.Now.ToString("HH:mm");
            _instance.CurrentDayString = ReturnDayString();
            _instance.CurrentMonthAndDayNumber = ReturnMonthAndDayNumber();
        }
    }
