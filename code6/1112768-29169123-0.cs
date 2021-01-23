    void Code()
    {
       Boolean anyErrors = false;
       Console.WriteLine("a");
       anyErrors = true; // whenever something goes wrong.
       Console.WriteLine("b");
       if(anyErrors)
           throw new Exception("There were errors doing whatever I was trying to.");
    }
