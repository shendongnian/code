    private void MergeDictionaries()
    {
        var oldData = new Dictionary<string, Dictionary<int, Dictionary<int, Dictionary<int, int>>>>();
        var todayData = new Dictionary<string, Dictionary<int, Dictionary<int, Dictionary<int, int>>>>();
        
        foreach (var kvp in oldData)
        {
            Dictionary<int, Dictionary<int, Dictionary<int, int>>> today;
            if (!todayData.TryGetValue(kvp.Key, out today))
            {
                today = new Dictionary<int, Dictionary<int, Dictionary<int, int>>>();
                todayData.Add(kvp.Key, today);
            }
            foreach (var kvp2 in kvp.Value)
            {
                Dictionary<int, Dictionary<int, int>> today2;
                if (!today.TryGetValue(kvp2.Key, out today2))
                {
                    today2 = new Dictionary<int, Dictionary<int, int>>();
                    today.Add(kvp2.Key, today2);
                }
                foreach (var kvp3 in kvp2.Value)
                {
                    Dictionary<int, int> today3;
                    if (!today2.TryGetValue(kvp3.Key, out today3))
                    {
                        today3 = new Dictionary<int, int>();
                        today2.Add(kvp3.Key, today3);
                    }
                    foreach (KeyValuePair<int, int> kvp4 in kvp3.Value)
                    {
                        // What you do here determines what happens when there are key duplicates
                        today3[kvp4.Key] = kvp4.Value;
                    }
                }
            }
        }
    }
