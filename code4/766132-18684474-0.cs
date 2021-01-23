    string s = "12 34";
    string parts[] = s.Split();
    // Now parts[0] contains "12"
    //     parts[1] contains "34"
    int i1, i2;
    if (parts.Length == 2 &&
        Int32.TryParse(parts[0], out i1) &&
        Int32.TryParse(parts[1], out i2) )
    {
        ...
    }
