    int MyKeyCounter = 0;
    Timer CounterResetter = new Timer(1000);
    CounterResetter.Elapsed += ResetCounter();
    void OnKeyPressEvent(object sender, KeyPressEventArgs e)
    {
        MyKeyCounter++;
    }
    void ResetCounter()
    {
        if(MyKeyCounter == 1)
            Method1();
        else if (MyKeyCounter == 2)
            Method2();
        ...
    }
