    public static class Extensions
    {
        public static DbSet<T> Remove<T>(this DbSet<T> Input, Func<T, Boolean> Objects)
        {
            for (int i = 0; i < Input.Count(); i++)
            {
                var CurrentObject = Input.ElementAt(i);
                if (Objects(CurrentObject))
                {
                    Input.Remove(CurrentObject);
                }
            }
            return Input;
        }
        public static DbSet<T> Update<T>(this DbSet<T> Input, Func<T, Boolean> Objects, T NewModel)
        {
            for (int i = 0; i < Input.Count(); i++)
            {
                var CurrentObject = Input.ElementAt(i);
                if (Objects(CurrentObject))
                {
                    CurrentObject = NewModel;
                }
            }
            return Input;
        }
    }
