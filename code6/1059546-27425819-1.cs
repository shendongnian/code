      static void Main()
      {
        var ualie = new UserAlreadyLoggedInException("Hello");
        Console.WriteLine("nothing bad has happened yet; nothing thrown yet");
        throw ualie;
      }
