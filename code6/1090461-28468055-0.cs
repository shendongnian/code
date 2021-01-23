    public static class Extensions
    {
        public static T GetFirstOrException<T>(this IEnumerable<T> myList)
        {
            if (myList.Any())
            {
                return myList.First();
            }
            else
            {
                throw new NullReferenceException("Empty query!");
            }
        }
    }
