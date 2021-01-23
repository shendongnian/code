    public static class MyLinqExtensions
    {
        public static void MySelect<T>(this IEnumerable<IEnumerable<T>> superlist)
        {
            int index = 0;
            
            foreach (IEnumerable<T> list in superlist)
            {
                if (index < list.Count())
                {
                    yield return list.ElementAt(index);
                }
                index++;
            }
        }
    }
