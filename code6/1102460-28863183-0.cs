    public static IObservable<T> RateLimit<T>(this IObservable<T> source, TimeSpan duration)
    {
        return observable
            .Timestamp()
            .Scan(
                new
                {
                    Item = default(T),
                    Timestamp = DateTimeOffset.MinValue,
                    Keep = false
                },
                (a, x) =>
                {
                    var keep = a.Timestamp + duration <= x.Timestamp;
                    return new
                    {
                        Item = x.Value,
                        Timestamp = keep ? x.Timestamp : a.Timestamp,
                        Keep = keep
                    };
                }
            })
            .Where(a => a.Keep)
            .Select(a => a.Item);
    }
