    double logLength    = Math.Ceiling(Math.Log((double)sample.Count, 2.0));
    int    paddedLength = (int) Math.Pow(2.0, Math.Min(Math.Max(1.0, logLength), 14.0));
    AForge.Math.Complex[] complex = new AForge.Math.Complex[paddedLength];
    // copy all input samples
    int i = 0;
    for (; i < sample.Count; i++)
    {
        complex[i] = new AForge.Math.Complex(samples[i].GetTimeInSec(),0);
    }
    // pad with zeros
    for (; i < paddedLength; i++)
    {
        complex[i] = 0;
    }
