    public sealed partial class MainPage : Page
    {
        int secCount;
        int m;
        DispatcherTimer timerCount; //declare here, initialize in constructor
        TextBlock time; //declare here, initialize in constructor
        public MainPage()
        {
            this.InitializeComponent();
            time = new TextBlock();
            timer.Children.Add(time); //fix: only add ONCE
            //populate the Combobox
            cMinutes.Items.Add(0); 
            cMinutes.Items.Add(1);
            cMinutes.Items.Add(2);
            cMinutes.SelectedIndex = 2;
            m = Convert.ToInt32(cMinutes.SelectedValue);
            timerCount = new DispatcherTimer();
            timerCount.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timerCount.Tick += new EventHandler<object>(timer_tick);
            timerCount.Start();
        }
        private void timer_tick(object sender, object e)
        {
            time.Text = cHours.SelectedItem + ":" + m + ":" + secCount;
            secCount--;
            if (secCount < 0)
            {
                secCount = 59;
                m--;
                if (cMinutes.Items.Contains(m)) //fix: update Combobox's selected value
                    cMinutes.SelectedValue = m;
            }
        }
    }
    
