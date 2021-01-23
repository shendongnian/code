     Dictionary<string, string> listResultitem = new Dictionary<string, string>();
            foreach(var dic in list)
            {
                foreach (var dic2 in list2)
                {
                    if (dic["ID"] == dic2["ID"])
                    {
                        listResultitem = dic.Concat(dic2.Where(kvp => !dic.ContainsKey(kvp.Key))).ToDictionary(d => d.Key, d => d.Value);
                        listresult.Add(listResultitem);
                    }
                }
            }
