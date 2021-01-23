        private static List<KeyValuePair<int, int>> Method7()
        {            
            FastDictionary<int, int> dic = new FastDictionary<int, int>();
            for (int i = 0; i < input.Count; i++)
            {
                int number = input[i];
                int pos = dic.InitOrGetPosition(number);
                int curr = dic.GetAtPosition(pos);
                dic.StoreAtPosition(pos, ++curr);
            }
            var result = dic.ToList();
            partialSort(result, 10);
            return result;
        }
