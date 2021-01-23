    DateTime latestHit = DatetIme.MinValue;
    Machine historicEvent;
    private void eventRxVARxH(MachineClass Machine)
    {
        log.Debug("Event fired");
     
        if(latestHit - DateTime.Now < TimeSpan.FromXYZ() // too fast
        {
            // ignore second hit, too fast
            historicEvent = Machine; // or some property
            return;
        }
        latestHit = DateTime.Now;
        // it was slow enough, do processing
        ...
        // process historicEvent
        ...
        historicEvent = Machine; 
    }
