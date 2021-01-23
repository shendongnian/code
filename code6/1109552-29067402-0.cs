        string[] joinedList = listOfArrays.JoinMultiple(",");
        ...
        public static string[] JoinMultiple(this List<string[]> lists,string delimiter)
        {
            return lists.SelectMany(
                strings => strings.Select((s, i) => new {s, i}))
                .ToLookup(arg => arg.i, arg => arg.s)
                .Select(grouping => string.Join(delimiter, grouping)).ToArray();
        }
