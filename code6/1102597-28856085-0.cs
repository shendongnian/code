    List<Dictionary<string, int>> listDic = new List<Dictionary<string, int>>();
                Dictionary<string, int> di = new Dictionary<string, int>();
                di.Add("apple", 1);
                listDic.Add(di);
    
                di = new Dictionary<string, int>();
                di.Add("mango", 2);
    
                di = new Dictionary<string, int>();
                di.Add("grapes", 3);
    
                Dictionary<string, int> item = listDic.Where(c => c.ContainsKey("apple")).FirstOrDefault();
                if (item != null)
                {
                    string key = item.FirstOrDefault().Key;
                    int value = item.FirstOrDefault().Value;
                }
