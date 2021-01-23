    List<int> result = new List<int>();
    string[] times = { "120:15:10:2345", "30:10:40:5346", "110:30:00" };
    foreach (string time in times)
    {
        string[] parts = time.Split(':');
        for (int i = 0; i < parts.Length; i++)
        {
            if (result.Count <= i) { result.Add(Convert.ToInt32(parts[i])); }
            else { result[i] += Convert.ToInt32(parts[i]); }
        }
    }
    string resultString = string.Join(":", result);
