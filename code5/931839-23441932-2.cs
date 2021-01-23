        private static List<KeyValuePair<int, int>> Method6()
        {            
            FastDictionary<int, int> dic = new FastDictionary<int, int>();
            for (int i = 0; i < input.Count; i++)
            {
                int number = input[i];
                int pos = dic.InitOrGetPosition(number);
                int curr = dic.GetAtPosition(pos);
                dic.StoreAtPosition(pos, ++curr);
            }
            var sorted_results = dic.OrderByDescending(x => x.Value).ToList();
            return sorted_results;
        }
