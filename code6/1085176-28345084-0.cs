    public interface IThemeContract : IContract
    {
        /// <summary>
        /// Theme name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Theme description
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Array of expected resources dictionaries
        /// </summary>
        IListContract<string> ResourceDictionaries { get; }
    }
