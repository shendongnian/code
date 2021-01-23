        private Dictionary<int, bool> CompareDictionaries(Dictionary<int, bool> dic1, Dictionary<int, bool> dic2)
        {
            Dictionary<int, bool> dic3 ;
            dic3  = new Dictionary<int, bool>();
            foreach (KeyValuePair<int, bool> pair in dic1)
            {
                // keep KeyValuePair of dic2
                if ( ! ((dic2.ContainsKey(pair.Key)) && (dic2[pair.Key] == pair.Value)))
                {
                    dic3.Add(pair.Key, pair.Value);
                }
            }
            return dic3;
        }
