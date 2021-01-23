    public class ListObjectComparator<T>
    {
        public delegate bool ComparePredicate(T one, T two);
    
        #region Public Methods
    
        public static IEnumerable<T> Run(List<T> originalItems, List<T> newItems, ComparePredicate comparer)
        {
            for (int i = 0; i < originalItems.Count; i++)
            {
                if (comparer(originalItems[i], newItems[i]))
                {
                    yield return originalItems[i];
                }
            }
        }
    
        #endregion
    }
