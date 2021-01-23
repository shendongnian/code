    while ((line = s.ReadLine()) != null)
    {
    
        string[] parts = new string[40];
        parts=line.Split(' ');
        int a;
        for (a = 0; a <= (parts.Length - 1); a++)
        {
    
            if (parts[a] == "if")
            {
                node = node + 1;
                edge = edge + 1;
                int b = a + 2;
                Console.Write(parts[b]);
                if (((a + 2) < parts.length) && (parts[a + 2]) == "{")
                {
                    node = node + 1;
                } 
            }
        }
    }
