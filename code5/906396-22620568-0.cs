    AppActivityTimer activityTimer; // In my app, this is a member variable of the main window
    
    activityTimer = new AppActivityTimer(
         30*1000,   // plain timer, going off every 30 secs - not useful for your question
         5*60*1000, // how long to wait for no activity before firing OnInactive event - 5 minutes
         true);     // Does mouse movement count as activity?
    activityTimer.OnInactive += new EventHandler(activityTimer_OnInactive);
    activityTimer.OnActive += new PreProcessInputEventHandler(activityTimer_OnActive);
    activityTimer.OnTimePassed += new EventHandler(activityTimer_OnTimePassed);
    void activityTimer_OnTimePassed(object sender, EventArgs e)
    {
         // Regular timer went off
    }
    void activityTimer_OnActive(object sender, PreProcessInputEventArgs e)
    {
         // Activity detected (key press, mouse move, etc) - close your slide show, if it is open
    }
    void activityTimer_OnInactive(object sender, EventArgs e)
    {
         // App is inactive - activate your slide show - new full screen window or whatever
         // FYI - The last input was at:
         // DateTime idleStartTime = DateTime.Now.Subtract(activityTimer.InactivityThreshold);
    }
