    String phoneNumber = "1800ab";
    for(int x=0; x < phoneNumber.Length; x++)
    {
       if(Char.IsLetter(phoneNumber[x]))
       {
          switch(phoneNumber[x].ToString().ToLower())
          {
             case "a":
             case "b":
             case "c":
               //This is number 2!
             break;
             
          }
       }
    }
