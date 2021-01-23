    void timerTick(object sender, EventArgs e)
    {
        if (!IsHolding){
            return;
        }
        UtilityStoryboardManager.PlayerStoryboard("End", (_) =>{
            IsHolding = false;
            //call some function or  perform some logic
            timer.Stop();
            //How Can a eventhandler delegate remove itself ??
            //timer.Tick -= timerTick;
        }, null);
     (sender as Timer).Tick-=timerTick; // removes the event
    }
