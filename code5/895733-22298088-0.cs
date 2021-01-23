    if(loginUsername == "login")
    {
      Console.WriteLine("Type in your username");
      string loginUser = Console.ReadLine();
      int lineCount=1;
      foreach(var line in File.ReadLines("LoginFile.txt"))
     {
       if(line.Contains(loginUser))
       {
       Console.WriteLine("UserName found in Line No = "+ lineCount);
       break;
       }
       lineCOunt++;
     }
    }
