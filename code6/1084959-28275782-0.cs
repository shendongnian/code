    public class RunningTime: INotifyPropertyChanged
    {
        public string runtime = "";
        private DispatcherTimer timer;
        private int runtimeInt = 65;
        public static string str_time = "";
        public RunningTime()
        {
            LoadTimer();
        }
        public string RunTime
        {
            get
            {
                return runtime;
            }
            set
            {
                if (runtime != value)
                {
                    runtime = value;
                    OnPropertyChanged("RunTime");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
        public void LoadTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            if (runtimeInt > 1)
            {
                runtimeInt--;
                string min = ((runtimeInt / 60) < 10) ? "0" + (runtimeInt / 60).ToString() : (runtimeInt / 60).ToString();
                string sec = ((runtimeInt % 60) < 10) ? "0" + (runtimeInt % 60).ToString() : (runtimeInt % 60).ToString();
                str_time = string.Format("{0}:{1}", min, sec);
                this.RunTime = str_time;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Time's Up");
            }
        }
    }
