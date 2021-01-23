    private int i = 0;
    private int stop = 15; //number of times I want the motor to stop
    private Timer bTimer; //initialise timer -> Thats wrong: nothing is INITIALIZED here its just defined
    
    private void btnGo_Click(object sender, EventArgs e) //On click
    {
        i = 0;
        stop = Convert.ToInt32(tbIntervalStops.Text); //using int because double is a floating point number like 12.34 and for counting only full numbers will be needed
    
        bTimer = new System.Timers.Timer(waittime); //time I want the motor to wait + Here the Timer is INITIALIZED
    
        bTimer.Elapsed += PerformMove; //Adds the Eventhandler, What should be called when the time is over
        bTimer.Enabled = true; //This starts the timer. It enables running like pressing the start button on a stopwatch
    
    }
    
    private void PerformMove(Object source, ElapsedEventArgs e) //event to move motor
    {
        //movemotor
        i++;
    
        if (i == stop) //if stop would be a double here we will have the danger to get not a true because of rounding problems
        {
            bTimer.Stop();
            //now enable the Garbage Collector to remove the Timer instance 
            bTimer.Elapsed -= PerformMove; //This removes the Eventhandler
            bTimer.Dispose(); //This frees all resources held by the Timer instance.  
            bTimer = null; 
        }
    }
