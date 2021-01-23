        /// <summary>
        /// Returns the By locator used to find the element
        /// </summary>
        /// <returns></returns>
        public static By GetLocator(this IWebElement element)
        {
            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = element.GetType().GetField("bys", BindingFlags.Instance | BindingFlags.NonPublic);
            // Retrieve the value of the field, and cast as necessary
            return ((List<By>)field.GetValue(element))[0];
        }
