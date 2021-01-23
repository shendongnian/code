    public static class Extensions
    {
        public static IEnumerable<T> Remove<T>(this DbSet<T> Input, Func<T, Boolean> Objects) where T : class
        {
            var I = Input.Where(Objects).ToList();
            for (int i = 0; i < I.Count; i++)
            {
                Input.Remove(I[i]);
            }
                return Input;
        }
        public static IEnumerable<T> Update<T>(this DbSet<T> Input, Func<T, Boolean> Objects, Action<T> UpdateAction) where T : class
        {
            var I = Input.Where(Objects).ToList();
            I.ForEach(UpdateAction);
            return I;
        }
    }
