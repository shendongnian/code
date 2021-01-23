        /// <summary>
    /// Resource manager that uses resources found in the exceptions folder before falling back to the built-in resource file.
    /// </summary>
    public class OverridenResourceManager : ResourceManager
    {
        #region Constructors and Destructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OverridenResourceManager "/>lass.
        /// </summary>
        /// <param name="name">
        /// The name of the resource file.
        /// </param>
        /// <param name="culture">
        /// The string culture to find resources for.
        /// </param>
        public OverridenResourceManager(string name, Assembly culture)
            : base(name, culture)
        {
            this.Name = name.Replace("AssemblyName.Localization.", string.Empty);
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Gets or sets a function that return a dictionary of overrides for the currentsite
        /// </summary>
        public static Func<Dictionary<string, string>> TextOverridesDictionary { get; set;}
        /// <summary>
        /// Gets or sets the name of the resources class to handle.
        /// </summary>
        public string Name { get; set; }
        #endregion
        #region Public Methods and Operators
        /// <summary>
        /// Gets the resource named <paramref name="name"/> for the given <paramref name="culture"/>.
        /// Tries to use the value in an exceptions file (through a pre-built dictionary), if any,
        /// otherwise uses the built-in method.
        /// </summary>
        /// <param name="name">
        /// The name of the resource to get.
        /// </param>
        /// <param name="culture">
        /// The string culture to get the resource for.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> containing the value of the resource.
        /// </returns>
        public override string GetString(string name, CultureInfo culture)
        {
            if (TextOverridesDictionary != null)
            {
                // As we are only giving one file we need to fully qualify the name we are looking for
                var resourceName = this.Name + '.' + name;
                // TextOverridesDictionary contains a closure to get the dictionary
                // from the session's website configuration object
                var overrides = TextOverridesDictionary();
                if (overrides != null && overrides.ContainsKey(resourceName))
                {
                    return overrides[resourceName];
                }
            }
            return base.GetString(name, culture);
        }
    }
