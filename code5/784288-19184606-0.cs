    public static class GroupExtender
    {
        public static IEnumerable<T> Mix<T>(this IEnumerable<IEnumerable<T>> groups)
        {
            // enumerate once
            var enumerable = groups as IList<IEnumerable<T>> ?? groups.ToList(); 
            //stop case
            if (!(enumerable.Any(g=>g.Any())))
                return new List<T>();
            // get first elements, iterate over the IEnumerable trimmed of these
            return enumerable
                    .SelectMany(g => g.Take(1))
                    .Concat(enumerable.Select(g => g.Skip(1)).Mix());
        }
    }
