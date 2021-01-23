    string[] lines = File.ReadAllLines("sample.txt");
    List<string> list1 = new List<string>();
    List<string> list2 = new List<string>();
    foreach (var line in lines)
    {
        string[] values = line.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        list1.Add(values[0]);
        list2.Add(values[1]);
     }
