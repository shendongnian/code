    TrackGain trackGain = new TrackGain(44100, 16);
    foreach (SampleSet sampleSet in track) {
        trackGain.AnalyzeSamples(sampleSet.leftSamples, sampleSet.rightSamples);
    }
    double gain = trackGain.GetGain();
    double peak = trackGain.GetPeak();
