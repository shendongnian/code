    string[] lines = File.ReadAllLines("sample.txt");
    int sum = 0;
    foreach (string line in lines.Skip(2))
    {
        sum += Convert.ToInt32(line.Trim().Split(' ').Last());
    }
