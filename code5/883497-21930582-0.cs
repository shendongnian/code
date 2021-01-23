    public static class Extensions
    {
        public static void MergeFrom<TSource, TDestination>(this TDestination dest, TSource source)
        {
            var fieldPairs = typeof(TDestination)
                .GetFields()
                .Join(
                    typeof(TSource).GetFields(),
                    p => p.Name,
                    a => a.Name,
                    (bp, ap) => new { Source = bp, Destination = ap });
            foreach (var pair in fieldPairs)
            {
                pair.Destination.SetValue(dest, pair.Source.GetValue(source));
            }
        }
    }
