    String[] lines = File.ReadAllLines("turn.txt");
    String[] parts = new String[] {};
        foreach (string line in lines)
        {
            parts = line.Split(',');
            if (parts.length > 1) {
                break;
            }
            //Console.WriteLine(line);
        }
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
