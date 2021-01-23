    string[,] P = new string[2, 3] { 
                                        { "John", "Smith", "17" }, 
                                        { "James", "Sawyer", "31" } 
                                    };
    
    using (StreamWriter s_w = new StreamWriter(target))
    {
        s_w.WriteLine("{0,-15}  {1,-15}  {2,-15}","Firstname", "Lastname" ,"Age");
    
        for (int i = 0; i < 2; i++)
        {
            s_w.WriteLine("{0,-15}  {1,-15}  {2,-15}", P[i, 0], P[i, 1], P[i, 2]);
        }
    }
