    /// <summary>
        /// extension that validates if Json string is copmplient to TSchema.
        /// </summary>
        /// <typeparam name="TSchema">schema</typeparam>
        /// <param name="value">json string</param>
        /// <returns>is valid?</returns>
        public static bool IsJsonValid<TSchema>(this string value)
            where TSchema : new()
        {
            bool res = true;
            //this is a .net object look for it in msdn
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //first serialize the string to object.
            var obj = ser.Deserialize<TSchema>(value);
            //get all properties of schema object
            var properties = typeof(TSchema).GetProperties();
            //iterate on all properties and test.
            foreach (PropertyInfo info in properties)
            {
                // i went on if null value then json string isnt schema complient but you can do what ever test you like her.
                var valueOfProp = obj.GetType().GetProperty(info.Name).GetValue(obj, null);
                if (valueOfProp == null)
                    res = false;
            }
            return res;
        }
