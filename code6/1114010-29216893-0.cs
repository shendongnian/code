    public static class ObservableExtensions
    {
        public static ImmutableSortedDictionary<decimal, MarketDepthLevel>
            ToLadder(this IObservable<MarketDepthLevel> source)
        {
            return source.Scan(
                ImmutableSortedDictionary<decimal, MarketDepthLevel>.Empty,
                    (lastLadder, depthLevel) => 
                        lastLadder.ContainsKey(depthLevel.Price)
                          ? lastLadder[depthLevel.Price] = depthLevel
                          : lastLadder.Add(depthLevel));
        }
    }
