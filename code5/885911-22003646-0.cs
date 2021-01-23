    public static void deleteRecord(string num)
    {
        var lines = File.ReadAllLines("Records.txt").ToList();
        if (lines.Remove(num) == true)
        {
            File.WriteAllLines("Records.txt", lines.ToArray<string>());
        }
    }
