    List<int> exampleList = new List<int> { 1, 3, 5, 6, 7, 8, 6, 5, 6, 6 };
    List<int> customSelection = new List<int> { 1, 5, 6, 6, 8 };
    
    var diffList = new List<int>(exampleList.Count);
    var customSelectionDic = customSelection.GroupBy(n => n)
                                            .ToDictionary(g => g.Key, g => g.Count());
    exampleList.ForEach(n =>
        {
            int count = 0;
            if (customSelectionDic.TryGetValue(n, out count))
            {
                if (count == 1)
                    customSelectionDic.Remove(n);
                else
                    customSelectionDic[n] = count - 1;
            }
            else
                diffList.Add(n);
        });
    // diffList: { 3, 7, 5, 6, 6 }
