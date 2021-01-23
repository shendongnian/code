    static bool IsFullRange(DateRange[] dateRanges, int year)
    {
        // We shouldn't modify input parameters :-)
        // So we clone it
        dateRanges = (DateRange[])dateRanges.Clone();
        // Sort the array
        Array.Sort(dateRanges, (p, q) => p.Start.CompareTo(q.Start));
        // We skip dateRanges that are fully in previous years
        int i = Array.FindIndex(dateRanges, p => p.End.Year >= year);
        if (i == -1)
        {
            return false;
        }
        // The dateRange starts after the first of the year
        if (dateRanges[i].Start > new DateTime(year, 01, 01))
        {
            return false;
        }
        // We skip the first element
        for (i = i + 1; i < dateRanges.Length; i++)
        {
            if (dateRanges[i].Start > new DateTime(year + 1, 01, 01))
            {
                // Already on another year
                break;
            }
            // Overlap
            if (dateRanges[i].Start <= dateRanges[i - 1].End)
            {
                return false;
            }
        }
        // Does the last range "covers" the end of the year?
        if (dateRanges[i - 1].End < new DateTime(year, 12, 31))
        {
            return false;
        }
        return true;
    }
