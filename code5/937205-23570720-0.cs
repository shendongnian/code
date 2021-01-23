      var dictionary = new Dictionary<string, IList<Object>>
                        {
                            {"1", new List<object> {1, 0, 1, 1, 1, 1}},
                            {"2", new List<object> {1, 2, 3, 4, 5, 6}},
                            {"3", new List<object> {1, 0, 1, 1, 1, 1}}
                        };
        var dictionaryHashSets = dictionary.ToDictionary(k=>k.Key, v=> new HashSet<Object>(v.Value));
        var reverseDictionary = dictionaryHashSets.GroupBy(pair => pair.Value, HashSet<Object>.CreateSetComparer()).ToDictionary(gk => gk.Key, gv => gv.Select(pair => pair.Key));
