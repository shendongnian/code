    public static IEnumerable<T> SortAndGroupByRelationship<T, TKey>(this IEnumerable<T> objs, Func<T, TKey> keySelector, Func<T, T, bool> relationship) where TKey : IComparable<TKey> {
        // Group items which are related.
        var groups = new List<List<T>>();
        foreach (var obj in objs) {
            bool grouped = false;
            // Attempt to place named object into an existing group.
            foreach (var group in groups)
                if (relationship(obj, group[0])) {
                    group.Add(obj);
                    grouped = true;
                    break;
                }
            // Create new group for named object.
            if (!grouped) {
                var newGroup = new List<T>();
                newGroup.Add(obj);
                groups.Add(newGroup);
            }
        }
        // Sort objects within each group by name.
        foreach (var group in groups)
            group.Sort( (a, b) => keySelector(a).CompareTo(keySelector(b)) );
        // Sort groups by name.
        groups.Sort( (a, b) => keySelector(a[0]).CompareTo(keySelector(b[0])) );
        // Flatten groups into resulting array.
        var sortedList = new List<T>();
        foreach (var group in groups)
            sortedList.AddRange(group);
        return sortedList;
    }
