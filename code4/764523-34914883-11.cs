    /// <summary>
    ///     Acts as a base implementation for all derived classes.
    /// </summary>
    public abstract class BaseClass : IBaseClass {
        /// <summary>
        ///     Initialises a new instance of the <see cref="BaseClass"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        protected BaseClass(string title)
        {
            // Set the title.
            Title = title;
        }
        #region Implementation of IBaseClass
        /// <summary>
        ///     Gets the title of the MEF Exported class.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; private set; }
        #endregion
    }
