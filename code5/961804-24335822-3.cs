    int[] result = new int[3]; //Assuming the format is always as in OP
    string[] times = { "120:15:10", "30:10:40", "110:30:00" };
    foreach (string time in times)
    {
        string[] parts = time.Split(':');
        for (int i = 0; i < parts.Length; i++)
        {
            result[i] += Convert.ToInt32(parts[i]);
        }
    }
    TimeSpan ts = TimeSpan.FromSeconds(result[1] * 60 + result[2]);
    result[0] += ts.Hours; result[1] = ts.Minutes; result[2] = ts.Seconds;
    string resultString = string.Join(":", result);
