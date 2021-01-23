    public static int GetRate(DateTime date)
    {
        // Normally these 'seasons' and rates would not be hard coded here
        const int offSeasonRate = 125;
        var winterSeason = new Season
        {
            StartDate = DateTime.Parse("November 15"), 
            EndDate = DateTime.Parse("January 12"), 
            Rate = 150
        };
        var springSeason = new Season
        {
            StartDate = DateTime.Parse("May 20"), 
            EndDate = DateTime.Parse("June 15"), 
            Rate = 140
        };
        var summerSeason = new Season
        {
            StartDate = DateTime.Parse("July 10"), 
            EndDate = DateTime.Parse("August 31"), 
            Rate = 170
        };
        // Create a list of all the seasons
        var seasons = new List<Season> {winterSeason, springSeason, summerSeason};
        // Loop through all the seasons and see if this date is in one of them
        foreach (var season in seasons)
        {
            if (season.ContainsDate(date))
            {
                // Note: depending on your implementation, Rate could be a multiplier
                // in which case you would return (offSeasonRate * season.Rate);
                return season.Rate;
            }
        }
        // If we get this far, the date was not in a 'season'
        return offSeasonRate;
    }
