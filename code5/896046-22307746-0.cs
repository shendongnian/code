    string str = "This is     a  test";
    List<string> spaceList = new List<string>();
    var temp = str.TakeWhile(char.IsWhiteSpace).ToList();
    List<char> charList = new List<char>();
    foreach (char c in str)
    {
        if (c == ' ')
        {
            charList.Add(c);
        }
        if (charList.Any() && c != ' ')
        {
            spaceList.Add(new string(charList.ToArray()));
            charList = new List<char>();
        }
    }
