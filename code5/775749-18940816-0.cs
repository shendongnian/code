    string[] splitValues = inputString.Split(new string[] { "??", "\r\n" }, StringSplitOptions.None);
    for (int i = 0; i < splitValues.Length; i += 2)
    {
        Console.WriteLine("value={0} index={1}", splitValues[i], splitValues[i + 1]);
    }
