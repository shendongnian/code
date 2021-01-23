    public static class Extensions
    {
        public static int CountUniqueDate(this List<Measure> items)   //<= measure is your T type
        {
            return items.DistinctBy(i => i.DateMeasured).Count();
        }
    }
