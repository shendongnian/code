    List<string> data = new List<string>();
    int calculatedValue = 10;
    for (int i = 1; i <= 20; i++)
    {
        data.Add(string.Format("{0}, {1}", i, calculatedValue));
        calculatedValue += 20 * (i + 1) - 10;
    }
    for (int i = 0; i < data.Count; i++)
    {
        Console.WriteLine(data[i]);
    }
    File.WriteAllLines(@"data.txt", data.ToArray());
