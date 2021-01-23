    string periodValue = "201410";
    string[] lines = File.ReadAllLines("sample.txt");
    for (int i = 0; i < lines.Length; i++)
    {
        lines[i] = lines[i].Replace("Attend_10", "Attend_10_" + periodValue);
    }
    File.WriteAllLines("out.txt", lines);
