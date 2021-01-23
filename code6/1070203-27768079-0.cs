    private enum Phases
    {
    	None,
    	Prep,
    	WorkOut,
    	Rest
    }
    
    private Phases thisPhase;       // phase tracker
    private int workOutCount;       // 8 cycle counter
    private void Timer1_Tick(object sender, EventArgs e)
    {
    	Timer1.Enabled = false;
    
    	// ToDo: Fiddle with controls as needed
        // also the durations...not sure if a new Prep
        // follows the final rest or if they are the same
    	switch (thisPhase) {
    		case Phases.None:
    			// start things off
    			thisPhase = Phases.Prep;
    			Timer1.Interval = 10000;
    			// prep time
    			break;
    
    		case Phases.Prep:
    			workOutCount = 1;
    			thisPhase = Phases.WorkOut;
    			Timer1.Interval = 20000;
    			// work out time
    			break;
    
    		case Phases.WorkOut:
    			thisPhase = Phases.Rest;
    			Timer1.Interval = 10000;
    			// rest time
    			break;
    
    		case Phases.Rest:
    			workOutCount += 1;
    
    			if (workOutCount == 8) {
    				thisPhase = Phases.Prep;
    				// perhaps to None, if there is an instruction timeout
    				Timer1.Interval = 10000;
    				// prep time
    				// actually means 10sec rest + 10 prep before next workout task
    			} else {
    				// next workout starts in...
    				Timer1.Interval = 10000;
    				// prep time
    			}
    
    			break;
    	}
    	Timer1.Enabled = true;
    }
