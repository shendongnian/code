    void Main()
    {
        var c1 = new char[] { 'a', 'b', 'c', 'd', 'a', 'b', 'c', 'h', 't' };
        var c2 = new char[] { 'c', 'h', 't' };
        
        if (c1.Contains(c2))
        {
            // do something
        }
        
        int i = c1.IndexOf(c2);
    }
    
    public static class ArrayExtensions
    {
        public static bool Contains<T>(this T[] array, T[] subarray) where T : IComparable
        {
            return array.IndexOf(subarray) >= 0;
        }
        
        public static int IndexOf<T>(this T[] array, T[] subarray) where T : IComparable
        {
            for (int i = 0; i < array.Length - subarray.Length + 1; i++)
            {
                bool found = true;
                
                for (int j = 0; j < subarray.Length; j++)
                {
                    if (array[i + j].CompareTo(subarray[j]) != 0)
                    {
                        found = false;
                        break;
                    }
                }
                
                if (found) return i;
            }
            
            return -1;
        }
    }
