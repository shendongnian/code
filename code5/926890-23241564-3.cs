    static IEnumerable<Tuple<T,T>> MakeAllPairs<T>(this IEnumerable<T> data) {
        var items = data.ToList();
        for (var i = 0 ; i != items.Count ; i++) {
            var a = items[i];
            for (var j = i+1 ; j != items.Count ; j++) {
                var b = items[i];
                yield return Tuple.Create(a, b);
            }
        }
    }
