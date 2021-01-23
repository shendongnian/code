    List<string> list2 = new List<string>();
           
    string path = "xy"; //your path
    string[] lines = File.ReadAllLines(path);
    int[][] result = lines
                .Select(line => 
                    line
                    .Split(' ')
                    .Select(numberText => int.Parse(numberText))
                    .ToArray()).ToArray();
    foreach (int[] line in result)
    {
        list2.Add(string.Join(", ", line)); // or whatever format you want the text to be
    }
