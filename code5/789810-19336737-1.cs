    string[] lines = File.ReadAllLines("log.txt");
    //Create an array with lines.Length rows and 2 columns
    string[,] table = new string[lines.Length,2];
    for (int i = 0; i < lines.Length; i++)
    {
         //Split the line in 2 with the | character
         string[] parts = lines[i].Split('|');
         //Store them in the array, trimming the spaces off
         table[i,0] = parts[0].Trim();
         table[i,1] = parts[1].Trim();
    }
