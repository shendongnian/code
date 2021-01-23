    /// <summary>
    ///     Acts as a base implementation for all derived special classes.
    /// </summary>
    public abstract class DerivedSpecialBaseClass : BaseClass 
    {
        protected DerivedSpecialBaseClass()
            : this("DerivedSpecialBaseClass")
        {
            /* IoC Friendly Constructor */
        }
        /// <summary>
        ///     Initialises a new instance of the <see cref="BaseClass"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        protected DerivedSpecialBaseClass(string title) : base(title)
        {
            /* Constructor Logic */
        }
        #region Implementation of IDerivedSpecialBaseClass
        /// <summary>
        ///     Gets the special property.
        /// </summary>
        /// <value>
        ///     The special property.
        /// </value>
        public abstract string SpecialProperty { get; }
        #endregion
    }
