    string[,] P = new string[2, 3] { 
                                        { "John", "Smith", "17" }, 
                                        { "James", "Sawyer", "31" } 
                                    };
    
    using (StreamWriter s_w = new StreamWriter(target))
    {
        string row = string.Format("{0,-30}{1,-30}{2,10}", "Firstname", "Lastname", "Age");
        s_w.WriteLine(row);
    
        for (int i = 0; i < 2; i++)
        {
            row = string.Format("{0,-30}{1,-30}{2,10}", P[i,0], P[i,1], P[i,2]);
            s_w.WriteLine(row);
        }
    }
