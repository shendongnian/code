    public static IList<T> ReorderList(this IList<T> lstMain,Func<T,int?> getter, int forRandom)
    {
        List<T> result = new List<T>();
        Random rnd = new Random();
        result.AddRange(lstMain.Where(x => getter(x).GetValueOrDefault(int.MaxValue) < forRandom).OrderBy(x => getter(x).GetValueOrDefault(int.MaxValue)));
        result.AddRange(lstMain.Where(x => x.getter(x).GetValueOrDefault(int.MaxValue) == forRandom).Shuffle(rnd));
        result.AddRange(lstMain.Where(x => getter(x).GetValueOrDefault(int.MaxValue) > forRandom).OrderBy(x => xgetter(x).GetValueOrDefault(int.MaxValue)));
        return result;
    }
