    public static class ExtensionMethods
    {
        public static IEnumerable<IEnumerable<T>> GetSubSets<T>(this IEnumerable<T> list, int size, Predicate<T> filter)
        {
            return GetSubSetsInternal(list.ToList().FindAll(filter), size);
        }
        public static IEnumerable<IEnumerable<T>> GetSubSets<T>(this IEnumerable<T> list, int size)
        {
            return GetSubSetsInternal(list, size);
        }
        private static IEnumerable<IEnumerable<T>> GetSubSetsInternal<T>(this IEnumerable<T> list, int size)
        {
            var vFinalList = new List<IList<T>>();
            var c = size;
            var vList = list.ToList();
            var vListSize = list.Count();
            if (c <= 0 || size > vListSize) return vFinalList;
            
            c -= 1;
            var indexs = new int[size];
            var vFirstSubList = new List<T>();
            for (var j = 0; j <= (size - 1); j++)
            {
                indexs[j] = j;
                vFirstSubList.Add(vList[j]);
            }
            
            vFinalList.Add(vFirstSubList);
            while (indexs[0] !=(vListSize - size) && vFinalList.Count < 2147483647)
            {
                if (indexs[c] < c + (vListSize - size))
                {
                    indexs[c]++;
                    var vSubList = new List<T>();
                    foreach (var j in indexs) vSubList.Add(vList[j]);
                    vFinalList.Add(vSubList);
                }
                else
                {
                    do
                    {
                        c -= 1;
                    } while (indexs[c] == c + (vListSize - size));
                    indexs[c] += 1;
                    for (var j = c + 1; j <= (size - 1); j++) indexs[j] = indexs[j - 1] + 1;
                    var vSubList = new List<T>();
                    foreach (var j in indexs) vSubList.Add(vList[j]);
                    vFinalList.Add(vSubList);
                    c = size - 1;
                }
            }
            return vFinalList;
        }
    }
