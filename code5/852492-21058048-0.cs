    new Thread(()=> 
    {    
        string blinkExit = ". . .";           //Variable for blinking periods after 'exit'
        Console.Write("\n\nPress any key to exit");              //Displays a message to press any key to exit in the console
        while (true)
        {
            WriteBlinkingText(blinkExit, 500, true);
            WriteBlinkingText(blinkExit, 500, false);
        }
    }).Start();
        
