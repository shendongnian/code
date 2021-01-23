    switch (e.Result.Text)
    {
        case "Good morning":
            Scot.Speak("Morning, Jeffrey! How are you today?");
            if(e.Result.Text == "Terrible, absolutely terrible")
            {
                Scot.Speak("Oh, I hope you feel better sir");
            }
            break;           
    }
