    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone)
             where T : ICloneable
        {
            var list = (IList<T>)Activator.CreateInstance(listToClone.GetType());
            foreach (var item in listToClone)
            {
                list.Add((T)item.Clone());
            }
            return list;
        }
    }
