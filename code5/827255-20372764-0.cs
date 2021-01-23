    public static IQueryable<PlayedMatch> By(this IQueryable<PlayedMatch> matches, Period period)
    {
        return matches.Where(pm => pm.Details.DateTime >= period.Start && pm.Details.DateTime < period.End);
    }
    public static ICollection<PlayedMatch> By(this ICollection<PlayedMatch> matches, Period period)
    {
        return matches.Where(pm => pm.Details.DateTime >= period.Start && pm.Details.DateTime < period.End);
    }
    public static IEnumerable<PlayedMatch> By(this IEnumerable<PlayedMatch> matches, Period period)
    {
        return matches.Where(pm => pm.Details.DateTime >= period.Start && pm.Details.DateTime < period.End);
    }
