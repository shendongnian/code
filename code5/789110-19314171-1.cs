    private static readonly List<DateTime> SimpleCollection = 
        Enumerable.Range(1, SimpleSize).Select(t => new DateTime(DateTime.Now.Ticks + t)).ToList();
    public static IEnumerable<Complex<DateTime>> GetComplexOnDemand()
    {
        for (int i = 1; i <= ComplexSize; i+=2)
        {
            yield return new Complex<DateTime>() { InnerValue = SimpleCollection[i] };
        }
    }
