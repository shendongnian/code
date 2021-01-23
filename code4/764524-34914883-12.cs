    [Export("DerivedClasses", typeof(BaseClass))]
    public class DerivedClassA : BaseClass 
    {
        public DerivedClassA()
            : this("DerivedClassA")
        {
            /* IoC Friendly Constructor */
        }
        /// <summary>
        ///     Initialises a new instance of the <see cref="BaseClass"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public DerivedClassA(string title) : base(title)
        {
            /* Construction Logic */
        }
    }
