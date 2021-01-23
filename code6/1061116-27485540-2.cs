    var result = context.AsEnumerable();
    var oldStr = "";
    var resultEnumerator = result.GetEnumerator();
    Observable.FromEventPattern(h => txt.TextChanged += h, h => txt.TextChanged -= h)
             .Select(s => txt.Text)
             .DistinctUntilChanged().Throttle(TimeSpan.FromMilliseconds(300))
             .Subscribe(s =>
             {
                 if (s.Contains(oldStr))
                     result = result.Where(t => t.Contains(s));
                 else
                     result = context.Where(t => t.Contains(s));
                 resultEnumerator = result.GetEnumerator();
                 oldStr = s;
                 // and probably start iterating resultEnumerator again,
                 // but perhaps not on this thread.
             });
