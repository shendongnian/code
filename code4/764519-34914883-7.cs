    /// <summary>
    ///     Acts as a base class for all generic special classes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DerivedGenericBaseClass<T> : DerivedSpecialBaseClass, IDerivedSpecialBaseClass<T>
        where T : struct
    {
        #region Implementation of IDerivedGenericBaseClass<T>
        /// <summary>
        ///     Does stuff and things.
        /// </summary>
        /// <param name="thing">The thing.</param>
        public abstract void DoStuffWith(T thing);
        #endregion
    }
