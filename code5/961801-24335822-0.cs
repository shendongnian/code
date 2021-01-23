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
    string resultString = string.Join(":", result);
