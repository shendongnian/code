    [Export("DerivedSpecialClasses", typeof(DerivedSpecialBaseClass))]
    public class DerivedSpecialA : DerivedSpecialBaseClass
    {
        /// <summary>
        ///     Initialises a new instance of the <see cref="DerivedSpecialA"/> class.
        /// </summary>
        public DerivedSpecialA()
            : this("DerivedSpecialA")
        {
            /* IoC Friendly Constructor */
        }
        /// <summary>
        ///     Initialises a new instance of the <see cref="DerivedSpecialA"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public DerivedSpecialA(string title)
            : base(title)
        {
            /* Construction Logic */
        }
        #region Implementation of IDerivedSpecialBaseClass
        /// <summary>
        ///     Gets the special property.
        /// </summary>
        /// <value>
        ///     The special property.
        /// </value>
        public override string SpecialProperty
        {
            get { return @"Hello, from DerivedSpecialA"; }
        }
        #endregion
    }
