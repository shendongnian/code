    Dictionary<string, int> results = new Dictionary<string, int>();
    string text = "1234#224859#123567#11#4322#43#155";
    string[] list = text.Split('#');
    foreach (string s in list)
    {
        int tempResult = -1;
        for (int i = 0; i < s.Length - 1; i++)
        {
            if(s.ElementAt(i) == s.ElementAt(i + 1))
            {
                tempResult = i;
                break;
            }
        }
        results.Add(s, tempResult);
    }
    foreach (KeyValuePair<string, int> pair in results) 
    {
        Console.WriteLine(pair.Key + ": " + pair.Value);
    }
