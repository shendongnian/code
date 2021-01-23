    using System.Timers; // this is Where the timer class lives.
    
    Timer fiveSecondTimer = new Timer(5000);
    fiveSecondTimer.Elapsed += () => { ShowImageHere }; //This is short hand 
    fiveSecondTimer.Start();
