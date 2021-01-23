    public static class MyExtentions
    {
        public static bool All(this IEnumerable<Instrument> enumer, Predicate<Instrument> pred)
        {
            return enumer.All(e => pred(e));
        }
    }
