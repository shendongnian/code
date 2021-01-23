    public static void Shuffle<T>(this T[] list)  
    {  
        Random rng = new Random();  
        int n = list.Length;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
