    public static class ListExtensions
    {
        public static bool Replace<T>(this List<T> list, int oldItemIndex, T newItem)
        {
            // many error handling stuff should be here!
            // return false or throw appropriate exception  
            
            //if everything is good then
            list[oldItemIndex] = newItem;
            return true;
        }
    }
