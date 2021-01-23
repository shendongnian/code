    for (var i = scanStart; i + _step <= scanEnd; i += _step)
    {
        var sample = _expeData.ReadSample(_channel, i);
        Series[0].Points.AddXY(i, sample);
    }
    
    Series[0].Sort(new PointComparer());
