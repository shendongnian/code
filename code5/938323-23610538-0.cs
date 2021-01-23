    for (; ; )
    { //Check that CurrentTime is equal to RunTime.
        Console.WriteLine("Runtime: " + RunTime.ToString() + "   |   " + "Current Time: " + CurrentTime.ToString() 
            + "PERIOD: " + Period.ToString());
        if ((CurrentTime.Year == RunTime.Year) && (CurrentTime.Month == RunTime.Month) &&
            (CurrentTime.Day == RunTime.Day) && (CurrentTime.Hour == RunTime.Hour) &&
            (CurrentTime.Minute == RunTime.Minute))
        {
            CopyFiles(RunTime, Period, obj);
            break;
        }
        CurrentTime = DateTime.Now;
        System.Threading.Thread.Current.Sleep(1000);  // sleep 1 second
    }
