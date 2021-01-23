    /// <summary>
    ///     Adapter class for MEF Imported contracts, deriving from BaseClass.
    /// </summary>
    public class Classes
    {
        /// <summary>
        ///     Gets or sets the derived classes.
        /// </summary>
        /// <value>
        ///     The derived classes.
        /// </value>
        /// <remarks>
        ///     This list will be populated via MEF.
        /// </remarks>
        [ImportMany("DerivedClasses", typeof(BaseClass))]
        private IEnumerable<IBaseClass> DerivedClasses { get; set; }
        /// <summary>
        ///     Gets or sets the derived special classes.
        /// </summary>
        /// <value>
        ///     The derived special classes.
        /// </value>
        /// <remarks>
        ///     This list will be populated via MEF.
        /// </remarks>
        [ImportMany("DerivedSpecialClasses", typeof(DerivedSpecialBaseClass))]
        private IEnumerable<IDerivedSpecialBaseClass> DerivedSpecialClasses { get; set; }
        /// <summary>
        ///     Gets or sets the derived special generic classes.
        /// </summary>
        /// <value>
        ///     The derived special generic classes.
        /// </value>
        /// <remarks>
        ///     This list will be populated via MEF.
        /// </remarks>
        [ImportMany("DerivedSpecialGenericClasses", typeof(DerivedGenericBaseClass<>))]
        private IEnumerable<IDerivedSpecialBaseClass> DerivedSpecialGenericClasses { get; set; }
        /// <summary>
        ///     Initialises a new instance of the <see cref="Classes"/> class.
        /// </summary>
        public Classes()
        {
            // NOTE: This is a generic application catalogue, for demonstration purposes.
            //       It is likely you'd rather use a Directory or Assembly catalogue
            //       instead, to make the application more scalable, in line with the MEF
            //       ideology.
            var catalogue = new ApplicationCatalog();
            var container = new CompositionContainer(catalogue);
            container.ComposeParts(this);
        }
        /// <summary>
        ///     Processes the classes.
        /// </summary>
        public void ProcessClasses()
        {
            foreach (var item in DerivedClasses)
            {
                DoSomethingInteresting(item);
            }
            foreach (var item in DerivedSpecialClasses)
            {
                DoSomethingInteresting(item);
            }
            foreach (var item in DerivedSpecialGenericClasses)
            {
                DoSomethingInteresting(item);
            }
        }
        private void DoSomethingInteresting(IBaseClass specialItem)
        {
            Console.WriteLine("Something interesting has been done with: " + specialItem.Title);
        }
    }
