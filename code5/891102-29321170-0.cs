            // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program... ");
        Console.ReadLine();
        Console.WriteLine("Terminating the application...");
