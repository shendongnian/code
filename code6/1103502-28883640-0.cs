    public interface  ITradingStrategy
    {
        string Name { get; }
        int len { get; }
        float lots { get; }
        bool trendFollow { get; }
    }
