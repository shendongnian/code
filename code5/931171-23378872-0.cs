           for (int k = 0; k <= smallList.Count; k++)
            {
                if (list[i].Density > 5 && smallList[k].Count < 10)
                {
                    smallList[k].Add(list[i]);
                }
                else smallList[k + 1].Add(list[i]);
            }
