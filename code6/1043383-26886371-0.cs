    /// <summary>
        /// Common DropDown model
        /// </summary>
        public class SelectListModel
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public int Value { get; set; }
    
            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>
            /// The item.
            /// </value>
            public string Item { get; set; }
    
            /// <summary>
            /// Gets or sets a value indicating whether this instance is selected.
            /// </summary>
            /// <value>
            /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
            /// </value>
            public bool IsSelected { get; set; }
        }
