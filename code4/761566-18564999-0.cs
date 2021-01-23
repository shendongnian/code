        public class Metronome
        {
            private DispatcherTimer _timer;
            public event TickHandler Tick;
            public delegate void TickHandler(Metronome m, TickArgs e);
            public Metronome()
            {
                _timer = new DispatcherTimer();
                _timer.Tick += Timer_Tick;
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                if (Tick != null)
                {
                    Tick(this, new TickArgs { Time = DateTime.Now });
                }
            }
            public void Start(int bbm)
            {
                _timer.Stop();
                _timer.Interval = TimeSpan.FromSeconds(60 / bbm);
                _timer.Start();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m, tbcheck, mediaElement1);
            m.Start(8); // 8bbm
        }
