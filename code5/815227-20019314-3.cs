    Dim trackGain As New TrackGain(44100, 16)
    For Each sampleSet As SampleSet In track
        trackGain.AnalyzeSamples(sampleSet.leftSamples, sampleSet.rightSamples)
    Next
    Dim gain As Double = trackGain.GetGain()
    Dim peak As Double = trackGain.GetPeak()
