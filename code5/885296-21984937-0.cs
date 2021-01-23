    public class User
        {
            #region Private Fields
    
            private readonly Dictionary<string, string> _keyValues = new Dictionary<string, string>();
    
            #endregion
    
            #region Public Properties
    
            /// <summary>
            ///     Gets the field names.
            /// </summary>
            /// <value>
            ///     The field names.
            /// </value>
            public IEnumerable<string> FieldNames
            {
                get { return _keyValues.Keys; }
            }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            ///     Gets or sets the <see cref="System.String" /> for the specified fieldName.
            /// </summary>
            /// <value>
            ///     The <see cref="System.String" />.
            /// </value>
            /// <param name="fieldName">The field name.</param>
            /// <returns>The value for the field if it could be found; otherwise null</returns>
            public string this[string fieldName]
            {
                get
                {
                    string value;
                    return _keyValues.TryGetValue(fieldName, out value) ? value : null;
                }
                set { _keyValues.Add(fieldName, value); }
            }
    
            /// <summary>
            ///     Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                string res = string.Empty;
                foreach (KeyValuePair<string, string> pair in _keyValues)
                {
                    res += string.Format("{0}={1};", pair.Key, pair.Value);
                }
                return res.TrimEnd(';');
            }
    
            #endregion
        }
