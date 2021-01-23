            var totalCombinations = 1;
            foreach (var l in lstMaster)
            {
                totalCombinations *= l.Count == 0 ? 1 : l.Count;
            }
            var res = new string[totalCombinations];
            for (int i = 0; i < lstMaster.Count; ++i)
            {
                var numOfEntries = totalCombinations / lstMaster[i].Count;
                for (int j = 0; j < lstMaster[i].Count; ++j)
                {
                    for (int k = numOfEntries * j; k < numOfEntries * (j + 1); ++k)
                    {
                        if (res[k] == null)
                        {
                            res[k] = lstMaster[i][j];
                        }
                        else
                        {
                            res[k] += lstMaster[i][j];
                        }
                    }
                }
            }
