    string originalString = "1111222233334444";
    List<string> test = new List<string>();
    int splitAt = 4; // change 4 with the size of strings you want.
    for (int i = 0; i < originalString.Length; i = i + splitAt)
    {
        if (originalString.Length - i >= splitAt)
            test.Add(originalString.Substring(i, splitAt));
        else
            test.Add(originalString.Substring(i,((originalString.Length - i))));
    }
