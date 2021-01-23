    Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
    public void AddIfNotExistInDic(int key, int Value) {
        List<int> list = null;
        if (dictionary.ContainsKey(key)) {
            list = dictionary[key];
        }
        else {
            list = new List<int>();
            dictionary.Add(key, list);
        }
        if (!list.Contains(Value)) {
            list.Add(Value);
        }
    }
