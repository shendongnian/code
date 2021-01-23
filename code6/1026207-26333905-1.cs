    List<string> ss = new List<string>();
    ss.Add("Bill had cat");
    string inputstring = "In 2012, Bill had a cat";
    foreach (string s in ss)
    {
        string[] split = s.Split(' ');
        string regex = ".*";
        for(int a = 0; a<split.Length;a++)
            regex += split[a]+".*";
        Match temp = Regex.Match(inputstring, regex);
        if (temp.Success)
        {
            MessageBox.Show("String \"" + inputstring  + "\" matches");
        }
    }
