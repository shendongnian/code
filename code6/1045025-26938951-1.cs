    for (int i = 0; i < 7; i++)
    {
        var stepPads = pads.Where(p => p.IndexSum == i);
        beginMs += interval;
        foreach (var pad in stepPads)
        {
            AnimatePad(ref beginMs, spd, pad, toColor);
        }
    }
