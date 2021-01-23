    public enum Quality
    {
        VeryLow=1,
        Low=2,
        Medium=3,
        High=4,
        Maximum=5,
    }
    private PhotoQuality NearestLowerPossibleValue(PhotoQuality quality)
    {
       int lenny = (int)quality;
       if (lenny != 1) lenny--;
       return (PhotoQuality)lenny;
    }
