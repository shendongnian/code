    public static T RandomElement(this IEnumerable<T> enumerable)
    {
        return enumerable.RandomElementUsing(new Random());
    }
    public static T RandomElementUsing(this IEnumerable<T> enumerable, Random rand)
    {
        int index = rand.Next(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }
