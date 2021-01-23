    List<string> ss = new List<string>();
    ss.Add("Bill cat had");
    ss.Add("Bill had a cat");
    ss.Add("Cat had Bill");
    string inputstring = "your text here";
    foreach (string s in ss)
    {
        string[] split = s.Split(' ');
        string regex = ".*";
        for(int a = 0; a<split.Length;a++)
            regex += split[a]+".*";
        Match temp = Regex.Match(inputstring, regex);
        if (temp.Success)
        {
            MessageBox.Show("String \"" + s + "\" is correct");
        }
    }
