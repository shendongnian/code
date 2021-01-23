    public SomeMethod()
    {
        var next = Increment("A2CZ"); // A2DZ
    }
    public string Increment(string code)
    {
        var arr = code.ToCharArray();
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            var c = arr[i];
            if (c == 90 || c == 57)
                continue;
            arr[i]++;
            return new string(arr);
        }
        return code;
    }
