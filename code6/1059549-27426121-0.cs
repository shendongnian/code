    private int i = 0;
    private const int stop = 15; //number of times I want the motor to stop
    private Timer bTimer; //initialise timer -> Thats wrong: nothing is INITIALIZED here its just defined
    
    private void btnGo_Click(object sender, EventArgs e) //On click
    {
        i = 0;
    
        bTimer = new System.Timers.Timer(waittime); //time I want the motor to wait + Here the Timer is INITIALIZED
    
        bTimer.Elapsed += PerformMove;
        bTimer.Enabled = true;
    
    }
    
    private void PerformMove(Object source, ElapsedEventArgs e) //event to move motor
    {
        //movemotor
        i++;
    
        if (i == stop)
        {
            bTimer.Stop();
            //now enable the Garbage Collector to remove the Timer instance 
            bTimer.Elapsed -= PerformMove;
            bTimer.Dispose();
            bTimer = null;
        }
    }
