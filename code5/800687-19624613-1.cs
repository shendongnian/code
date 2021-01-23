    private static void Main()
    {
        var sum = SumValuesFromFiles("File1.txt", "File2.txt", "File3.txt");
        
        Console.Write("Sum: {0}", sum);
        Console.ReadLine();
    }
    
    private static int SumValuesFromFiles(params string[] files)
    {
        Task<int>[] tasks = new Task<int>[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            // use a local copy for the parameter because i might get changed before the method is called
            string filename = files[i];
            
            tasks[i] = Task.Factory.StartNew(() =>
                                             {
                                                 string firstLine = System.IO.File.ReadLines(filename).First();
                                                 return int.Parse(firstLine);
                                             });
        }
        
        Task.WaitAll(tasks);
        
        return tasks.Sum(t => t.Result);
    }
