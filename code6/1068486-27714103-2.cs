    // Get the value of the earliest Bar.Time on each Instrument, and select the most recent of those.
    DateTime latestStartDate = xlinqInstruments.Max(instrument => instrument.Bars.Min(bar => bar.Time));
    // Get the value of the latest Bar.Time on each Instrument, and select the earliest of those.
    DateTime earliestEndDate = xlinqInstruments.Min(instrument => instrument.Bars.Max(bar => bar.Time));
    // Overwrite the Bars collection of each instrument with its contents truncated appropriately.
    // I'd suggest doing this with a foreach loop as opposed to what I've provided below, but that's just me.
    xlinqInstruments.ForEach(instrument => 
    {
        instrument.Bars = instrument.Bars.Where(obj => obj.Time >= latestStartDate && obj.Time <= earliestEndDate).ToList();
    });
