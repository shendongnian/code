    void YourCode (IOutputWriter writer)
    { 
         // ...
         writer.WriteLine(output);
    }
    void Main()
    {
        IOutputWriter writer;
        if (console)
        { 
            writer = new ConsoleWriter();
        }
        else
        { 
            writer = new StreamWriter();
        }
        YourCode (writer);
    }
