        static float clicks = 0;
        static float clickers = 0;
        static float clickerCost = 5;
        static long savedTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
        static bool buyClickerButtonFlag = false;
        static bool clickButtonFlag = false;
        public MainPage()
        {
            InitializeComponent();
            first.Click += ShowCounter;
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = TimeSpan.FromSeconds(5);
            t.Tick += ShowCounter;
            t.Start();
            System.Threading.Timer myTimer = new Timer(MyTimerCallback);
            myTimer.Change(10, 10);
        }
        private void ShowCounter(object sender, EventArgs e)
        {
            textBlck.Text = clicks.ToString();
        }
        private static void MyTimerCallback(object state)
        {
            clicks++; // added to check running
            if (true)
            {
                long nowTime = savedTime;
                long timePassed = nowTime - savedTime;
                //user input
                if (clickButtonFlag)
                {
                    clickButtonFlag = false;
                    clicks++;
                    System.Diagnostics.Debug.WriteLine("clicked!" + clicks);
                }
                if (buyClickerButtonFlag)
                {
                    buyClickerButtonFlag = false;
                    if (clicks > clickerCost)
                    {
                        clickers++;
                        clicks -= clickerCost;
                        clickerCost *= 1.6F;
                    }
                    System.Diagnostics.Debug.WriteLine("clicker bought!" + clickers);
                }
                //update vars
                if (timePassed > TimeSpan.TicksPerSecond)
                {
                    savedTime = nowTime;
                    nowTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
                    clicks += clickers;
                }
            }
        }
