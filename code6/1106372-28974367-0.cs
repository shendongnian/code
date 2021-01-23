    public static void FisherYatesShuffle<T>(this IList<T> list)  
    {  
        var rnd = new Random();  
        var x = list.Count;  
        while (x > 1) {  
            x--;  
            var y = rnd.Next(x + 1);  
            T value = list[y];  
            list[y] = list[x];  
            list[x] = value;  
        }  
    }
