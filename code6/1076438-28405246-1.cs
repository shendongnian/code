        /// <summary>
        /// Gets or sets the mapping delegate.
        /// </summary>
        /// <value>The mapping.</value>
        /// <remarks>Example: series1.Mapping = item => new HighLowItem(((MyType)item).Time,((MyType)item).Value);</remarks>
        public Func<object, HighLowItem> Mapping { get; set; }
