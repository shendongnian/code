        private static IEnumerable<dynamic> ApplySort(IEnumerable<dynamic> listToBeSorted, ICollection<KeyValuePair<string, string>> sorters)
        {
            var orderBy = (sorters == null || sorters.Count == 0) ? new KeyValuePair<string, string>("createddate", "1") : sorters.First();
            var thenBys = (sorters == null || sorters.Count == 1) ? new List<KeyValuePair<string, string>>() : sorters.Except(Enumerable.Repeat(orderBy, 1));
            var orderedEnumerable = orderBy.Value == "1"
                ? listToBeSorted.OrderBy(x => GetPropertyValue(x, orderBy.Key))
                : listToBeSorted.OrderByDescending(x => GetPropertyValue(x, orderBy.Key));
            orderedEnumerable = thenBys.Aggregate(orderedEnumerable, (current, thenBy) => thenBy.Value == "1"
                ? current.ThenBy(x => GetPropertyValue(x, thenBy.Key))
                : current.ThenByDescending(x => GetPropertyValue(x, thenBy.Key)));
            return orderedEnumerable.ToList();
        }
        private static object GetPropertyValue(dynamic obj, string propName)
        {
            Type t = obj.GetType();
            return t.GetProperty(propName).GetValue(obj, null);
        }
