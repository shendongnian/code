    static void MyInternCheck(string str)
    {
      var test = string.IsInterned(str);
      if ((object)test == (object)str)
        Console.WriteLine("Yes, your string instance is in the intern pool");
      else if (test == str)
        Console.WriteLine("An instance with the same value exists in the intern pool, but you have a different instance with that value");
      else if (test == null)
        Console.WriteLine("No instance with that value exists in the intern pool");
      else
        throw new Exception("Unexpected intern pool answer");
    }
