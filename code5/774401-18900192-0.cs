    public static string Join<T>(string separator, IEnumerable<T> values)
    {   
        using (IEnumerator<T> enumerator = values.GetEnumerator())
        {
            if (!enumerator.MoveNext())        
                return Empty;
            
            // ...        
        }
    }
