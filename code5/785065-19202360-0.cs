    //add timer to the webform so we can get the ControlID
    this.Form.Controls.Add(myTimer);
    //An AJAX control to update the web UI
    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
    //set timer to async it
    trigger.ControlID = myTimer.UniqueID;
    trigger.EventName = "Tick";     
    //now add the timer trigger to get its updates   
    UpdatePanel1.Triggers.Add(trigger);
