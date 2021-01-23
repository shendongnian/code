    DateTime latestStartDate = xlinqInstruments.Max(instrument => instrument.Bars.Min(bar => bar.Time));
    DateTime earliestEndDate = xlinqInstruments.Min(instrument => instrument.Bars.Max(bar => bar.Time));
    xlinqInstruments.ForEach(instrument => 
    {
        instrument.Bars = instrument.Bars.Where(obj => obj.Time >= latestStartDate && obj.Time <= earliestEndDate).ToList();
    });
