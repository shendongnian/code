    public static int GetRate(DateTime date)
    {
        // Normally these 'seasons' and rates would not be hard coded here
        const int offSeasonRate = 125;
        var winterHighSeason = new SeasonRate
        {StartMonth = 11, StartDay = 15, EndMonth = 1, EndDay = 12, Rate = 150};
        var springHighSeason = new SeasonRate
        {StartMonth = 5, StartDay = 20, EndMonth = 6, EndDay = 15, Rate = 140};
        var summerHighSeason = new SeasonRate
        {StartMonth = 7, StartDay = 10, EndMonth = 8, EndDay = 30, Rate = 170};
        // Create a list of all the seasons
        var highSeasons = new List<SeasonRate> 
        {winterHighSeason, springHighSeason, summerHighSeason};
        // Loop through all the seasons and see if this date is in one of them
        foreach (var highSeason in highSeasons)
        {
            if (highSeason.DateIsInSeason(date))
            {
                return highSeason.Rate;
            }
        }
        // If we get this far, the date was not in a 'season'
        return offSeasonRate;
    }
