    foreach (var line in System.IO.File.ReadAllLines(@"input_5_5.txt", Encoding.GetEncoding(1250)))
    {
        foreach (var col in line.Trim().Split(' ').Skip(1))
        {
            result[i, j] = int.Parse(col.Trim());
            j++;
        }
        i++;
    }
