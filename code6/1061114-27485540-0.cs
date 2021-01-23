    var result = context.AsEnumerable();
    var oldStr = "";
    var resultEnumerator = result.GetEnumerator();
    Observable.FromEventPattern(h => txt.TextChanged += h, h => txt.TextChanged -= h)
             .DistinctUntilChanged().Throttle(TimeSpan.FromMilliseconds(300))
             .Subscribe(s =>
             {
                 var newStr = txt.Text;
                 if (newStr.Contains(oldStr))
                     result = result.Where(t => t.StartsWith(txt.Text));
                 else
                     result = l.Where(t => t.StartsWith(txt.Text));
                 resultEnumerator = result.GetEnumerator();
                 oldStr = newStr;
                 // and probably start iterating resultEnumerator again,
                 // but perhaps not on this thread.
             });
