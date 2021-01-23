    public static int GetRate(DateTime date)
    {
        // Normally these 'seasons' and rates would not be hard coded here
        const int offSeasonRate = 125;
        var winterSeason = new Season
        {StartMonth = 11, StartDay = 15, EndMonth = 1, EndDay = 12, Rate = 150};
        var springSeason = new Season
        {StartMonth = 5, StartDay = 20, EndMonth = 6, EndDay = 15, Rate = 140};
        var summerSeason = new Season
        {StartMonth = 7, StartDay = 10, EndMonth = 8, EndDay = 30, Rate = 170};
        // Create a list of all the seasons
        var seasons = new List<Season> 
        {winterSeason, springSeason, summerSeason};
        // Loop through all the seasons and see if this date is in one of them
        foreach (var season in seasons)
        {
            if (season.ContainsDate(date))
            {
                return season.Rate;
            }
        }
        // If we get this far, the date was not in a 'season'
        return offSeasonRate;
    }
