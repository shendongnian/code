    public static class MyListExtensions {
        public static IEnumerable<T> TakeAndRemove<T>(this List<T> list, int count) {
            foreach(var n in list.Take(count))
                yield return n;
            source.RemoveRange(0, count);
        }
    }
    list1.AddRange(list2.TakeAndRemove(5));
