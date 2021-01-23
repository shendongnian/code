    public static class MyExtensions
    {
        public IEnumerable<T> MyIdCheck(this IEnumerable<T> input)
        {
            return input.Where(x => x.Id == 1 || x.Id == 12 || x.Id == 16);
        }
    }
