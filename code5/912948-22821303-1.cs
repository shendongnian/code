    private Stream NearestLowerPossibleValue(PhotoQuality quality)
    {
        return streamInfos.Where(si => si.Quality <= quality)
            .Aggregate((si1, si2) => si1.Quality > si2.Quality ? si1 : si2).Stream;
    }
