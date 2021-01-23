    for (var i1 = 0; i1 < listVal.Count; i1++)
            {
                var secondLevelList = listVal[i1];
                for (var i2 = 0; i2 < secondLevelList.Count; i2++)
                {
                    var thirdLevelList = secondLevelList[i2];
                    var alreadiInList = new Dictionary<double, List<Tuple<int, int, int>>>();
                    for (var d = 0; d < thirdLevelList.Count; d++)
                    {
                        var decVal = thirdLevelList[d];
                        if (!alreadiInList.ContainsKey(decVal))
                        {
                            alreadiInList.Add(decVal, new List<Tuple<int, int, int>>());
                            continue;
                        }
                        var firstMatchElIndex = thirdLevelList.IndexOf(decVal);
                        if (alreadiInList[decVal].All(x => x.Item3 != firstMatchElIndex))
                            alreadiInList[decVal].Add(new Tuple<int, int, int>(i1, i2, firstMatchElIndex));
                        alreadiInList[decVal].Add(new Tuple<int, int, int>(i1, i2, d));
                    }
                    SetListQ(listQ, alreadiInList.Where(x => x.Value.Count > 1).Select(x => x.Value));
                }
            }
    private void SetListQ(List<List<List<double>>> listQ, IEnumerable<List<Tuple<int, int, int>>> matches)
        {
            foreach (var match in matches)
            {
                var sum = match.Sum(tuple => listQ[tuple.Item1][tuple.Item2][tuple.Item3]);
                var avg = sum / match.Count;
                foreach (var tuple in match)
                    listQ[tuple.Item1][tuple.Item2][tuple.Item3] = avg;
            }
        }
