    // Keeps track of the number of blinks
    private int m_nBlinkCount = 0;
    
    // ...
    
    // tmrTimer is a component added to the form.
    tmrTimer.Tick += new EventHandler(OnTimerTick);
    
    m_nBlinkCount = 0;
    tmrTimer.Interval = 1000; // 1 second interval
    tmrTimer.Start();
    
    // ...
    
    private void OnTimerTick ( Object sender, EventArgs eventargs)
    {
    	if (label1.BackColor == Color.Red)
    		label1.BackColor = Color.Transparent;
    	else
    		label1.BackColor = Color.Red;
    		
    	m_nBlinkCount++;
    	
    	if ( m_nBlinkCount >= 10 )
    	    tmrTimer.Stop ();
    }
