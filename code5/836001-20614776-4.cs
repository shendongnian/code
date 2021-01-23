    string[] filelines = File.ReadAllLines("file.txt");
    string[][] arr = new string[filelines.Length][];
    for (int i = 0; i < filelines.Length; i++) 
    {
        arr[i] = filelines[i].Split(',');       // Note: no need for .ToArray()
    }
  
    // now convert
    string[,] arr2 = new string[arr.Length, arr.Max(x => x.Length)];
    for(var i = 0; i < arr.Length; i++)
    {
        for(var j = 0; j < arr[i].Length; j++)
        {
            arr2[i, j] = arr[i][j];
        }
    }
