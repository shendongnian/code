    public static T GetRandomItemForToday<T>(this IList<T> list)  
    {  
        Random rng = new Random(unchecked((int)DateTime.Today.Ticks));  
        return list[rng.Next(list.Count)];
    }
