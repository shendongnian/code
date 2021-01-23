        public static List<List<string>> GetAnagramEquivalents(List<string> InputArray)
        {
            Dictionary<string, List<string>> DictionaryList = new Dictionary<string, List<string>>();
            List<List<string>> ReturnList = new List<List<string>>();
            for (int x = 0; x < InputArray.Count; ++x)
            {
                char[] InputCharArray = InputArray[x].ToCharArray();
                Array.Sort(InputCharArray);
                string InputString = new string(InputCharArray);
                if (DictionaryList.ContainsKey(InputString))
                {
                    DictionaryList[InputString].Add(InputArray[x]);
                }
                else
                {
                    DictionaryList.Add(InputString, new List<string>());
                    DictionaryList[InputString].Add(InputArray[x]);
                }
            }
            foreach (var item in DictionaryList)
            {
                ReturnList.Add(item.Value);
            }
            return ReturnList;
        }
