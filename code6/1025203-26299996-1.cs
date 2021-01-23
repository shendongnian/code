    /// <summary>
    /// This is a class containing extension methods for AutoFixture.
    /// </summary>
    public static class AutoFixtureExtensions
    {
        #region Extension Methods For IPostprocessComposer<T>
        public static IEnumerable<T> CreateSome<T>(this IPostprocessComposer<T> composer, int numberOfObjects)
        {
            if (numberOfObjects < 0)
            {
                throw new ArgumentException("The number of objects is negative!");
            }
            IList<T> collection = new List<T>();
            for (int i = 0; i < numberOfObjects; i++)
            {
                collection.Add(composer.Create<T>());
            }
            return collection;
        }
        #endregion
    }
