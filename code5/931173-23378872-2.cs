           for (int k = 0; k <= filtered_list.Count; k++)
            {
                if (smallList[k].Count < 10)
                {
                    smallList[k].Add(list[i]);
                }
                else smallList[k + 1].Add(list[i]);
            }
