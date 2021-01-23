    int amp = 80;
    string[] commands = speech.Split(' ');    
    
    if (commands[0] == "speak")
    {
        switch (commands[1])
        {
            case "lower":
            {
                MARVIN.Volume = amp - 10;
                amp = MARVIN.Volume;
                MARVIN.Speak("Volume is lower");
                break;
            }
            case "louder":
            {
                MARVIN.Volume = amp + 10;
                amp = MARVIN.Volume;
                MARVIN.Speak("Volume is louder");
                break;
            }
        }
    }
