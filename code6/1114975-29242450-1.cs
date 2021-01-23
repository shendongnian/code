    public static void Main()
    {
        // For testing sake, I created some dummy files
        var file1 = @"D:\Public\Temp\File1.txt";
        var file2 = @"D:\Public\Temp\File2.txt";
        var file3 = @"D:\Public\Temp\File3.txt";
        // Validation that files exist and have same number 
        // of items is intentionally left out for the example
        // Read the contents of each file into a separate variable
        var days = File.ReadAllLines(file1);
        var dates = File.ReadAllLines(file2);
        var values = File.ReadAllLines(file3);
        var itemCount = days.Length;
        // The list of items read from each file
        var fileItems = new List<Tuple<string, string, string>>();
        // Add a new item for each line in each file
        for (int i = 0; i < itemCount; i++)
        {
            fileItems.Add(new Tuple<string, string, string>(
                days[i], dates[i], values[i]));
        }
        // Display the items in console window
        fileItems.ForEach(item =>
            Console.WriteLine("{0} {1} = {2}",
                item.Item1, item.Item2, item.Item3));
        // Example for how to order the items:
        // By days
        fileItems = fileItems.OrderBy(item => item.Item1).ToList();
        // By dates
        fileItems = fileItems.OrderBy(item => item.Item2).ToList();
        // By values
        fileItems = fileItems.OrderBy(item => item.Item3).ToList();
        // Order by descending
        fileItems = fileItems.OrderByDescending(item => item.Item1).ToList();
        // Show the values based on the last ordering
        fileItems.ForEach(item =>
            Console.WriteLine("{0} {1} = {2}",
                item.Item1, item.Item2, item.Item3));
    }
