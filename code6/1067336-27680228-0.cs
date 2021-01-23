    BlockingCollection<Tuple<string, List<string>>> bc = new BlockingCollection<Tuple<string, List<string>>>();
    private void GenerateDataFiles()
    {
        DirectoryInfo directory = new DirectoryInfo(@"D:\Data\");
        FileInfo[] array_FileInfo = directory.GetFiles("*.txt", SearchOption.TopDirectoryOnly);
        Parallel.ForEach(array_FileInfo, fileInfo => 
        {
            string[] array_Lines = File.ReadAllLines(fileInfo.FullName);
            // do some CPU-intensive data parsing and then add the processed data to the blocking collection
            // It has to be inserted in pairs (key = file path, value = list of strings to be written to this file)
            List<string> processedData = new List<string>();  // ... and add content
            bc.Add(new Tuple<string, List<string>>(fileInfo.FullName, processedData));
        });
        bc.CompleteAdding();
    }
    private void WriteDataToFiles()
    {
        foreach (var tuple in bc.GetConsumingEnumerable())
        {
            File.WriteAllLines(tuple.Item1, tuple.Item2);
        }
    }
