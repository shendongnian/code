        private static List<KeyValuePair<int, int>> Method11()
        {
            byte[] dic = new byte[input.Max() + 1];
            Dictionary<int, int> largeDic = new Dictionary<int, int>();
            int index = 0;
            int val = 0;
            for (int i = 0; i < input.Count; i++)
            {
                index = input[i];
                val = dic[index];
                if (val < 255)
                    dic[index] = (byte)(val + 1); // casting to byte
                else
                {
                    if (largeDic.ContainsKey(index))
                    {
                        largeDic[index]++;
                    }
                    else
                    {
                        largeDic.Add(index, 255 + 1);
                    }
                }
            }
			
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            if (largeDic.Count == 0)
            {
                list = partialSort(dic, 10);
            }
            else
            {
                if (largeDic.Count < 10)
                {
                    list.AddRange(largeDic.OrderByDescending(x => x.Value));
                    var tempList = partialSort(dic, 50);
                    list.AddRange(tempList.Except(list, new KeyValueComparer()).Take(10 - list.Count));
                }
                else
                {
                    list = largeDic.OrderByDescending(x => x.Value).Take(10).ToList();
                }
            }
            return list;
        }
		
