    public static class ListExtension
    {
        public static List<List<T>> MatchList<T>(this List<List<T>> list) where T : class
        {
            //will contain matched list element index
            var matchedList = new List<Tuple<int, int>>();
            for (var i = 0; i < list.Count - 1; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {
                    //add element to matchedList if all are equal.
                    var iElement = list.ElementAt(i);
                    var jElement = list.ElementAt(j);
                    if (iElement.Count != jElement.Count) continue;
                    var flag = !iElement.Where((t, k) => !iElement.ElementAt(k).Equals(jElement.ElementAt(k))).Any();
                    if (flag)
                    {
                        //add element here.
                        matchedList.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
    
            var item1 = matchedList.Select(d => d.Item1).ToList();
            var item2 = matchedList.Select(d => d.Item2).ToList();
            //distinct elements that matchced perfectly.
            var sameGroup = item1.Union(item2);
            for (var i = 0; i < list.Count; i++)
            {
                if (!sameGroup.Contains(i))
                {
                    //make it null where it did not matched as your requirement
                    list[i] = null;
                }
            }
            //finally return the updated list.
            return list;
        }
    }
