        var my_string = "In the end this is not the end";
        var groupCount = 2;
        var groups = new Dictionary<string, int>();
        var lastGroupCountWordIndexes = new Queue<int>();
        for (int i = 0; i < my_string.Length; i++)
        {
            if (my_string[i] == ' ' || i == 0)
            {
                lastGroupCountWordIndexes.Enqueue(i);
            }
            if (lastGroupCountWordIndexes.Count >= groupCount)
            {
                var firstWordInGroupIndex = lastGroupCountWordIndexes.Dequeue();
                var gruopKey = my_string.Substring(firstWordInGroupIndex, i - firstWordInGroupIndex);
                if (!groups.ContainsKey(gruopKey))
                {
                    groups.Add(gruopKey, 1);
                }
                else
                {
                    groups[gruopKey]++;
                }
            }
                            
        }
