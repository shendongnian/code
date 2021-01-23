      var timer = new Timer(5000);
	  bool timeUp = false;
	  string input = "";
	  timer.Elapsed += (o,e) =>  { timeUp = true; };
	  timer.Enabled = true;
    
      while(!timeUp) {
      	if (Console.KeyAvailable) 
      	{
      		char pressed = Console.ReadKey(true).KeyChar; 
      		Console.Write(pressed);
      		input+=pressed;
      	}
        System.Threading.Thread.Sleep(100);
      }
    
	  Console.WriteLine(input);
