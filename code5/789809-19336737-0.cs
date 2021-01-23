    string[] lines = File.ReadAllLines("log.txt");
    string[,] table = new string[lines.Length,2];
    for (int i = 0; i < lines.Length; i++)
    {
         string[] parts = lines[i].Split('|');
         table[i,0] = parts[0];
         table[i,1] = parts[1];
    }
