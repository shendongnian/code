    static void  check()
    {   int result
        string x = Console.ReadLine();
        if(int.TryParse(x, out result)
          Console.WriteLine("int");
        else
          Console.WriteLine("not int");   
    
    }
