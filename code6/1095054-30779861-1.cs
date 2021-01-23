        /// <summary>
        /// Test data provider
        /// </summary>
        /// <typeparam name="T">Type to return in enumerable</typeparam>
        /// <typeparam name="C">Configuration type that provide Filenames</typeparam>
        public sealed class TestCsvReader<T, C>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestCsvReader{T, C}"/> class.
            /// </summary>
            public TestCsvReader()
            {
                this.Config = (C)Activator.CreateInstance<C>();
            }
    
            /// <summary>
            /// Gets or sets the configuration.
            /// </summary>
            /// <value>
            /// The configuration.
            /// </value>
            private C Config { get; set; }
    
            /// <summary>
            /// Gets the filename.
            /// </summary>
            /// <value>
            /// The filename.
            /// </value>
            /// <exception cref="System.Exception">
            /// </exception>
            private string Filename
            {
                get
                {
                    try
                    {
                        string result = Convert.ToString(typeof(C).GetProperty(string.Format("{0}Filename", typeof(T).Name)).GetValue(this.Config));
                        if (!File.Exists(result))
                            throw new Exception(string.Format("Unable to find file '{0}' specified in property '{1}Filename' in class '{1}'", result, typeof(C).Name));
    
                        return result;
                    }
                    catch
                    {
                        throw new Exception(string.Format("Unable to find property '{0}Filename' in class '{1}'", typeof(T).Name, typeof(C).Name));
                    }
                }
            }
    
            /// <summary>
            /// Yields values from source
            /// </summary>
            /// <returns></returns>
            public IEnumerable Data()
            {
                string file = this.Filename;
    
                T[] result = null;
                using (StreamReader reader = File.OpenText(file))
                {
                    //TODO: do it here your magic
                }
                yield return new TestCaseData(result);
            }
    }
