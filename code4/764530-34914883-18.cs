    [Export("DerivedSpecialGenericClasses", typeof(DerivedGenericBaseClass<>))]
    public class DerivedSpecialGenericA<T> : DerivedGenericBaseClass<T>
        where T : struct
    {
        #region Overrides of DerivedSpecialBaseClass
        /// <summary>
        ///     Does stuff and things.
        /// </summary>
        /// <param name="thing">The thing.</param>
        public override void DoStuffWith(T thing)
        {
            Console.WriteLine("Doing Stuff and Things with " + thing.GetType().Name);
        }
        /// <summary>
        ///     Gets the special property.
        /// </summary>
        /// <value>
        ///     The special property.
        /// </value>
        public override string SpecialProperty
        {
            get { return @"Hello, from DerivedSpecialGenericA"; }
        }
        #endregion
    }
