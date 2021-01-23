      bool control = true;
      while(control)
      {
        favoriteBand = (Console.ReadLine());
        switch (favoriteBand)
        {
            case "1": Console.WriteLine("Don't Stop Believin'!"); control = false;break;            
            case "2": Console.WriteLine("More Than a Feeling!");control = false; break;
            case "3": Console.WriteLine("Come Sail Away!"); control = false;break;
            case "4": Console.WriteLine("Dust in the Wind!"); control = false;break;
            case "5": Console.WriteLine("Hot Blooded!"); control = false;break;
            case "6": control = false; break;
            default: Console.WriteLine("Error, invalid choice. Please choose a valid number.");  break;
        }    
      }
      
