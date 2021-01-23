    public class CPUClass
    {
        public ObservableCollection<KeyValuePair<double, double>> cpuChartList = new ObservableCollection<KeyValuePair<double, double>>();
        private object _lock = new object();
        private int _counter;
        private int _Limit = 30; //max 30 secs of data
        Timer _timer;
        public CPUClass()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _counter = 0;
        }
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(() => UpdateCollection());
        }
        void UpdateCollection()
        {
            lock (_lock)
            {
                _counter += 1;
                //Get the CpuUsage
                var cpuCurrent = GetCpuUsage();
                //Remove the oldest item
                if (cpuChartList.Count >= _Limit)
                    cpuChartList.RemoveAt(0);
                cpuChartList.Add(new KeyValuePair<double, double>(_counter, cpuCurrent));
            }
        }
       
    }
