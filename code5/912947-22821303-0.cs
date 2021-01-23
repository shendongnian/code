    struct StreamInfo : IComparable<StreamInfo>
    {
        public Stream Stream { get; set; }
        public PhotoQuality Quality { get; set; }
        public int CompareTo(StreamInfo other)
        {
            return Quality - other.Quality;
        }
    }
    public enum PhotoQuality
    {
        VeryLow,
        Low,
        Medium,
        High,
        Maximum,
    }
    List<StreamInfo> streamInfos;
    private Stream NearestLowerPossibleValue(PhotoQuality quality)
    {
        return streamInfos.Where(si => si.Quality <= quality).Max().Stream;
    }
