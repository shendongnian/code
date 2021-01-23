    while ((line = s.ReadLine()) != null)
    {
    
        string[] parts = new string[40];
        parts=line.Split(' ');
        int a;
        for (a = 0; a <= (parts.Length - 2); a++)
        {
    
            if (parts[a] == "if")
            {
                node = node + 1;
                edge = edge + 1;
                int b = a + 2;
                Console.Write(parts[b]);
                if ((parts[a + 2]) == "{")
                {
                    node = node + 1;
                } 
            }
        }
    }
