    int MyKeyCounter = 0;
    Timer CounterResetter = new Timer(1000);
    CounterResetter.Elapsed += ResetCounter;
    void OnKeyPressEvent(object sender, KeyPressEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            MyKeyCounter++;
            if(!CounterResetter.Enabled)
                CounterResetter.Start();
        }
    }
    void ResetCounter(Object source, ElapsedEventArgs e)
    {
        if(MyKeyCounter == 1)
            Method1();
        else if (MyKeyCounter == 2)
            Method2();
        ...
        MyKeyCounter = 0;
    }
