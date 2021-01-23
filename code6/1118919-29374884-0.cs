    using Extensions;
    
    namespace Extensions
    {
        public static class ArrayExtension
        {
            public static IEnumerable<int> GetIndeciesOf<T>(this T[] target, T val)
            {
                for (int i = 0; i < target.Length; i++)
                {
                    if (target[i].Equals(val))
                    {
                        yield return i;
                    }
                }
            }
        }
    }
