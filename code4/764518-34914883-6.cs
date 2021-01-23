    /// <summary>
    ///     Provides mechanisms for doingstuff and things.
    /// </summary>
    /// <typeparam name="T">The type of things to do stuff with.</typeparam>
    public interface IDerivedSpecialBaseClass<T> : IDerivedSpecialBaseClass 
        where T : struct
    {
        /// <summary>
        ///     Does stuff and things.
        /// </summary>
        /// <param name="thing">The thing.</param>
        void DoStuffWith(T thing);
    }
