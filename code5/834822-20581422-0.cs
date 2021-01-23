    if(File.Exisis("info.txt"))
            {
               var TextLines = File.ReadAllLines("info.txt");
               foreach (var line in TextLines)
             {
               yourarray.Add(line);
             }
            }
