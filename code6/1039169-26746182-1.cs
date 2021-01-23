    List<Letter> keyPool = new List<Letter>();
    var letters = key.Split(new string[] { System.Environment.NewLine },
        System.StringSplitOptions.RemoveEmptyEntries);
    foreach(var letter in letters)
    {
        keyPool.Add((Letter)Enum.Parse(typeof(Letter), letter);
    }
