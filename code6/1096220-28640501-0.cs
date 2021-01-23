    Random _random = new Random();
    int num;
    char let;
    string TempName = "~";
    string sTempPath = string.Empty;
    while (TempName.Length < 12 || File.Exists(sTempPath))
    {
        num = _random.Next(0, 26);
        let = (char)('a' + num);
        TempName = TempName + let;
        sTempPath = sDirectory + @"\" + TempName + @"." + sExt;
    }
