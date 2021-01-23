    /// <summary>
    /// Helper class for SqlDataReader, which allows for the calling code to retrieve a value in a generic fashion.
    /// </summary>
    public static class SqlReaderHelper
    {
        private static bool IsNullableType(Type theValueType)
        {
            return (theValueType.IsGenericType && theValueType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }
        /// <summary>
        /// Returns the value, of type T, from the SqlDataReader, accounting for both generic and non-generic types.
        /// </summary>
        /// <typeparam name="T">T, type applied</typeparam>
        /// <param name="theReader">The SqlDataReader object that queried the database</param>
        /// <param name="theColumnName">The column of data to retrieve a value from</param>
        /// <returns>T, type applied; default value of type if database value is null</returns>
        public static T GetValue<T>(this SqlDataReader theReader, string theColumnName)
        {
            // Read the value out of the reader by string (column name); returns object
            object theValue = theReader[theColumnName];
            // Cast to the generic type applied to this method (i.e. int?)
            Type theValueType = typeof(T);
            // Check for null value from the database
            if (DBNull.Value != theValue)
            {
                // We have a null, do we have a nullable type for T?
                if (!IsNullableType(theValueType))
                {
                    // No, this is not a nullable type so just change the value's type from object to T
                    return (T)Convert.ChangeType(theValue, theValueType);
                }
                else
                {
                    // Yes, this is a nullable type so change the value's type from object to the underlying type of T
                    NullableConverter theNullableConverter = new NullableConverter(theValueType);
                    return (T)Convert.ChangeType(theValue, theNullableConverter.UnderlyingType);
                }
            }
            // The value was null in the database, so return the default value for T; this will vary based on what T is (i.e. int has a default of 0)
            return default(T);
        }
    }
