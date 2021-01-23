    public partial class App : Application
    {
        public static PhoneApplicationFrame RootFrame { get; private set; }
        public DispatcherTimer gAppTimer = new DispatcherTimer();
        public void OnTimerTick(Object sender, EventArgs args)
        {
            MessageBox.Show("TIMER fired");
        }
        public App()
        {
            gAppTimer.Interval = TimeSpan.FromSeconds(2);
            // Sub-routine OnTimerTick that will be called at specified intervall
            gAppTimer.Tick += OnTimerTick;
            // starting the timer
            gAppTimer.Start();
            // rest of the code
