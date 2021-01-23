    private readonly DispatcherTimer timer = new DispatcherTimer();
    private int currentValue;
    private int endValue;
    public MainPage()
    {
        ...
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += TimerTick;
    }
    private void TimerTick(object sender, object e)
    {
        currentValue++;
        textBlock.Text = currentValue.ToString();
        if (currentValue >= endValue)
        {
            timer.Stop();
        }
    }
    private void AnimateText(int start, int end)
    {
        currentValue = start;
        endValue = end;
        textBlock.Text = currentValue.ToString();
        if (currentValue < endValue)
        {
            timer.Start();
        }
    }
