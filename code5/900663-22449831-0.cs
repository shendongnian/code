    if (speech.Contains("lower"))
    {
        MARVIN.Volume = amp - 10;
        amp = MARVIN.Volume;
        MARVIN.Speak("Volume is lower");
    }
