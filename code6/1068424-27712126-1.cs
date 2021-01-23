        static List<string> Intersect7(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            var list = new List<string>();
            foreach (var key in dic1.Keys)
            {
                if (dic2.ContainsKey(key))
                {
                    list.Add(dic1[key]);
                    list.Add(dic2[key]);
                }
            }
            return list;
        }
