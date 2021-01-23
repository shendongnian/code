        public static List<List<T>> GetPerms<T>(List<T> list, int chainLimit)
        {
            if (list.Count() == 1)
                return new List<List<T>> { list };
            return list
                .Select((outer, outerIndex) =>
                            GetPerms(list.Where((inner, innerIndex) => innerIndex != outerIndex).ToList(), chainLimit)
                .Select(perms => (new List<T> { outer }).Union(perms).Take(chainLimit)))
                .SelectMany<IEnumerable<IEnumerable<T>>, List<T>>(sub => sub.Select<IEnumerable<T>, List<T>>(s => s.ToList()))
                .Distinct(new PermComparer<T>()).ToList();
        }
        class PermComparer<T> : IEqualityComparer<List<T>>
        {
            public bool Equals(List<T> x, List<T> y)
            {
                return x.SequenceEqual(y);
            }
            public int GetHashCode(List<T> obj)
            {
                return (int)obj.Average(o => o.GetHashCode());
            }
        }
