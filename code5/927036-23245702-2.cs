    public class ListObjectComparator<T>
    {
    
        #region Public Methods
    
        public static IEnumerable<T> Run(IEnumerable<T> originalItems, IEnumerable<T> newItems, Func<T,T,bool> comparer)
        {
            foreach(var originalItem in originalItems)
            {
                bool found = false;
                foreach (var newItem in newItems)
                {
                    if (comparer(originalItem,newItem))
                    {
                        found = true;
                        itemToRemove = newItem;
                        break;
                    }
                }
                if (found)
                {
                    newItems.Remove(itemToRemove);
                    yield return originalItem;
                }
            }
        }
    
        #endregion
    }
