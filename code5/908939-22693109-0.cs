    Stopwatch chrono = new Stopwatch();
    chrono.Start();
    bool isMyComputerOn = true;
    while (isMyComputerOn)
    {
       Console.SetCursorPosition(1,1);
       Console.WriteLine("Time : "+chrono.Elapsed);
    }
