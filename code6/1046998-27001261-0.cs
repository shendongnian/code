      string myname = "";
      while (myname.Length<3 || myname.Length >10)
      {
        Console.WriteLine("Please enter your name (between 3 and 10 characters");
        myname = Console.ReadLine();
      }
      test.Name = myname;
