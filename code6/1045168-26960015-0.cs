    public static IEnumerable<Answer> FilterByKeyValue(this IEnumerable<Answer> query, KeyFilterModel[] filters)
    {
        if (filters != null && filters.Length > 0)
        {
            query = query.Where(a => PassesAnyFilter(a, filters));
        }
        return query;
    }
    private static bool PassesAnyFilter(Answer answer, KeyFilterModel[] filters)
    {
        foreach (var filter in filters)
            foreach (var value in filter.FilterValues)
            {
                if (answer.RespondentEntryID.HasValue && answer.RespondentEntry.Values.Any(g => g.Key.Name.Contains(filter.Key) && g.Values.Contains(value)))
                return true;
            }
        return false;
    }
