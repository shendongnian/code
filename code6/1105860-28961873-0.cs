    static void Main()
    {      
        Action[] actions = new Action[3];
        int i = 0;
        for (var c = 0; c < 3; c++)
            actions[i++] = () => Console.Write(c);
        for (int j = 0; j < 3; j++)
        {
            actions[j]();
        }
        foreach (Action a in actions) a();    
        Console.ReadLine(); 
    }
