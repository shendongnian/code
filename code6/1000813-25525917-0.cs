    String[] lines = File.ReadAllLines("turn.txt");
        foreach (string line in lines)
        {
            String[] parts = line.Split(',');
            //Console.WriteLine(line);
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
