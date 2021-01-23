    DateTime latestHit = DatetIme.MinValue;
    private void eventRxVARxH(MachineClass Machine)
    {
        log.Debug("Event fired");
        if(latestHit - DateTime.Now < TimeSpan.FromXYZ() // too fast
        {
            // ignore second hit, too fast
            return;
        }
        latestHit = DateTime.Now;
        // it was slow enough, do processing
        ...
    }
