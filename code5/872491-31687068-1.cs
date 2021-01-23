    public static int check1 = 0; //these "checks" are global variables
    public static int check2 = 0;
    switch (e.Result.Text)
    {
        case "Terrible, absolutely terrible":
            if(check2 == 0)
            {
                Scot.Speak("What are you talking about?");
            }   
            break;
        case "Good morning":
            Scot.Speak("Morning, Jeffrey! How are you today?");
            //if(e.Result.Text == "Terrible, absolutely terrible")
            //{
                //Scot.Speak("Oh, I hope you feel better sir");
            //}
            check1++;
            check2++; 
            break;           
    }
    if(e.Result.Text == "Terrible, absolutely terrible")
    {
        if(check1 == 1)
        {
            if(check2 == 1)
            {
                Scot.Speak("Oh, I hope you feel better sir");
                check1--;
            }
            check2--;
        }
    }    
