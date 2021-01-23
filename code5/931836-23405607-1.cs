    private static List<KeyValuePair<int, int>> Method5()
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < input.Count; i++)
        {
            int number = input[i];
            if (dic.ContainsKey(number))
                dic[number]++;
            else
                dic.Add(number, 1);
        }
        var result = dic.ToList();
        partialSort(result, 10);
        return result;
    }
    private static void partialSort(List<KeyValuePair<int, int>> list, int k)
    {
        for (int i = 0; i < k; ++i)
        {
            int maxIndex = i;
            int maxValue = list[i].Value;
            for (int j = i+1; j < list.Count; ++j)
            {
                if (list[j].Value > maxValue)
                {
                    maxIndex = j;
                    maxValue = list[j].Value;
                }
            }
            var temp = list[i];
            list[i] = list[maxIndex];
            list[maxIndex] = temp;
        }
    }
