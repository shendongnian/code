    /// <summary>
    /// Extension method for name value collection
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Get typed value from query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetValueFromQueryString<T>(this NameValueCollection queryString, string value) where T : struct, IConvertible
        {
            if (queryString[value] != null)
            {
                var thisType = default(T);
                var typeCode = thisType.GetTypeCode();
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        {
                            bool queryStringValue;
                            if (bool.TryParse(queryString[value], out queryStringValue))
                            {
                                return (T)Convert.ChangeType(queryStringValue, typeCode);
                            }
                        }
                        break;
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        {
                            if (typeof(T).IsEnum)
                            {
                                var numberValue = queryString.GetValueFromQueryString<int>(value);
                                if (numberValue.HasValue && Enum.IsDefined(typeof(T), numberValue.Value))
                                {
                                    return (T)(object)numberValue;
                                }
                                else
                                {
                                    T queryStringValueForEnum;
                                    if (Enum.TryParse(queryString[value], true, out queryStringValueForEnum))
                                    {
                                        return queryStringValueForEnum;
                                    }
                                }
                            }
                            int queryStringValue;
                            if (int.TryParse(queryString[value], out queryStringValue))
                            {
                                return (T)Convert.ChangeType(queryStringValue, typeCode);
                            }
                        }
                        break;
                    case TypeCode.DateTime:
                        {
                            DateTime queryStringValue;
                            if (DateTime.TryParse(queryString[value], out queryStringValue))
                            {
                                return (T)Convert.ChangeType(queryStringValue, typeCode);
                            }
                            break;
                        }
                }
            }
            return null;
        }
        /// <summary>
        /// Get string value from query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetValueFromQueryString(this NameValueCollection queryString, string value)
        {
            return queryString[value];
        }
    }
