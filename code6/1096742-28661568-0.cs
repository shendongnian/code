    var list1 = new List<string>() { "free bar", "hello world", "foo" };
    var list2 = new List<string>() { "hello there world", "foobar", "bar" };
    var wordMap = new Dictionary<string, HashSet<int>>();
    
    for(int i = 0; i< list2.Count; i++)
    {
        var words = list2[i].Split(' ');
        foreach(var word in words)
        {
            if(!wordMap.ContainsKey(word))
            {
                wordMap[word] = new HashSet<int>();
            }
            wordMap[word].Add(i);
        }
    }
    
    foreach(var item in list1)
    {
        bool foundMatch = false;
        var words = item.Split(' ');
        for (int i = 0; i < list2.Count;i++ )
        {
            foundMatch = words.All(word => !wordMap.ContainsKey(word) ? false : wordMap[word].Contains(i));
            if(foundMatch)
            {
                Console.WriteLine("Found matching sentence in list 2: " + list2[i]);
            }
        }
    }
