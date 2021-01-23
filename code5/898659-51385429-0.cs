        /// <summary>
        /// Microsoft sends back ints as a string in byte form on DirectoryAttribute
        /// Because of that, we must convert bytes to string, and try to parse string to int.
        /// </summary>
        private static int TryGetAttributeValueAsInt(ref IEnumerable<DirectoryAttribute> resultAttrs, string propName)
        {
            int value = 0;
            string sInteger = TryGetAttributeValueAsString(ref resultAttrs, propName);
            if(!string.IsNullOrEmpty(sInteger))
            {
                //We will try to parse the string to an int
                if(!int.TryParse(sInteger, out value))
                {
                    //Unable to parse string to int, set value to 0
                    value = 0;
                }
            }
            return value;
        }
        private static string TryGetAttributeValueAsString(ref IEnumerable<DirectoryAttribute> resultAttrs, string propName)
        {
            string value = "";
            DirectoryAttribute da = resultAttrs.FirstOrDefault(r => r.Name.Equals(propName, StringComparison.OrdinalIgnoreCase));
            if (da != null && da.Count > 0)
            {
                value = da[0] as string;
            }
            return value;
        }
