    for (var i1 = 0; i1 < listVal.Count; i1++)
                for (var i2 = 0; i2 < listVal[i1].Count; i2++)
                {
                    var alreadyInList = new Dictionary<double, List<Tuple<int, int, int>>>();
                    for (var d = 0; d < listVal[i1][i2].Count; d++)
                    {
                        var decVal = listVal[i1][i2][d];
                        if (!alreadyInList.ContainsKey(decVal))
                        {
                            alreadyInList.Add(decVal, new List<Tuple<int, int, int>>());
                            continue;
                        }
                        var firstMatchElIndex = listVal[i1][i2].IndexOf(decVal);
                        if (alreadyInList[decVal].All(x => x.Item3 != firstMatchElIndex))
                            alreadyInList[decVal].Add(new Tuple<int, int, int>(i1, i2, firstMatchElIndex));
                        alreadyInList[decVal].Add(new Tuple<int, int, int>(i1, i2, d));
                    }
                    SetListQ(listQ, alreadyInList.Where(x => x.Value.Count > 1).Select(x => x.Value));
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
