    for (int i = 0; i < dateTime.Count; i++)
    {
        ...
        string filePath = Path.Combine(satimagesdir, "SatImage" + (i + last) + ".GIF");
        ...
    }
    last += dateTime.Count;
