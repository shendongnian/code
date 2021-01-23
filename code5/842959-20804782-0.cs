    string key_pressed="";
    while(key_pressed=="")
    {
      string key_pressed = Console.ReadLine().ToUpper();
      if (key_pressed.Equals("A"))
      {
         //code here
      }
      else if (key_pressed.Equals("B"))
      {
        //code here
      }
      // else-if cases for C and D
      else
      {
        // code for the "wrong key" case. Beep, perhaps.
        key_pressed=""; // so the loop continues
      }
    } // end of while loop
    
