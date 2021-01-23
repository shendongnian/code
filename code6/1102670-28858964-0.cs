    DispatcherTimer timeLeft;
    int timesTicked = 60;
    public QuickPage()
    {
        timeLeft = new Dispatcher();
        timeLeft.Tick += timeLeft_Tick;
        timeLeft.Interval = new TimeSpan(0,0,0,1);
    }
    private void QuestionGenerator()
    {
        timeLeft.Start();
        if (iAsked < 6)
        {
            //Code to generate random question
        }
    }
