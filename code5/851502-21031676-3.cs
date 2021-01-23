    public static double EstimateAccuracy<T>(Partitions<T> actual
        , Partitions<T> estimate)
    {
        int correctlyCategorized = 
            actual.High.Intersect(estimate.High).Count() +
            actual.Medium.Intersect(estimate.Medium).Count() +
            actual.Low.Intersect(estimate.Low).Count();
        double total = actual.High.Count()+
            actual.Medium.Count()+
            actual.Low.Count();
        return correctlyCategorized / total;
    }
