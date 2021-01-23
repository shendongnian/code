        /// <summary>
        /// Returns the StringLengthAttribute for a property based on the property name passed in.
        /// Use this method in the class or in a base class
        /// </summary>
        /// <param name="type">This type of the class where you need the property StringLengthAttribute.</param>
        /// <param name="propertyName">This is the property name.</param>
        /// <returns>
        /// StringLengthAttribute of the propertyName passed in, for the Type passed in
        /// </returns>
        public static StringLengthAttribute GetStringLengthAttribute(Type type, string propertyName)
        {
            StringLengthAttribute output = null;
            try
            {
                output = (StringLengthAttribute)type.GetProperty(propertyName).GetCustomAttribute(typeof(StringLengthAttribute));
            }
            catch (Exception ex)
            {
                //error handling
            }
            return output;
        } //GetStringLengthAttribute
        /// <summary>
        /// Returns the StringLengthAttribute for a property based on the property name passed in.
        /// Use this method in the class or in a base class
        /// </summary>
        /// <param name="propertyName">This is the property name.</param>
        /// <returns>
        /// StringLengthAttribute of the propertyName passed in, for the current class
        /// </returns>
        public StringLengthAttribute GetStringLengthAttribute(string propertyName)
        {
            StringLengthAttribute output = null;
            try
            {
                output = (StringLengthAttribute)this.GetType().GetProperty(propertyName).GetCustomAttribute(typeof(StringLengthAttribute));
            }
            catch (Exception ex)
            {
                //error handling
            }
            return output;
        } //GetStringLengthAttribute
    }
