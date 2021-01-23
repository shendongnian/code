    string msg = "1+1+1-2+2/2*4-2*3/23";
    Dictionary<char, List<int>> list = new Dictionary<char, List<int>>();
    for (int i = 0; i < msg.Length; i++)
    {
        if (!list.ContainsKey(msg[i]))
        {
            list.Add(msg[i], new List<int>());
            list[msg[i]].Add(i);
        }
        else
            list[msg[i]].Add(i);
    }
