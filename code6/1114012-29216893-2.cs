    public static class ObservableExtensions
    {
        public static IObservable<ImmutableSortedDictionary<decimal, MarketDepthLevel>>
            ToLadder(this IObservable<MarketDepthLevel> source)
        {
            return source.Scan(ImmutableSortedDictionary<decimal, MarketDepthLevel>.Empty,
                (lastLadder, depthLevel) =>
                    lastLadder.SetItem(depthLevel.Price, depthLevel));
        }
    }
