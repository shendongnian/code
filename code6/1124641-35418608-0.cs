    static void MyParse(string foo)
    {
        string[] split = foo.Split(',');
        Contract.Assert(split.Length == 4);
        string a = split[0];
        string b = split[1];
        string c = split[2];
        string d = split[3];
    }
