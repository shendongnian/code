        private static void GetChildPrivateProperties(IList<PropertyInfo> initialProperties, Type targetType, BindingFlags bindingAttr)
        {
            // fix weirdness with private PropertyInfos only being returned for the current Type
            // find base type properties and add them to result
            // also find base properties that have been hidden by subtype properties with the same name
            while ((targetType = targetType.BaseType()) != null)
            {
                foreach (PropertyInfo propertyInfo in targetType.GetProperties(bindingAttr))
                {
                    PropertyInfo subTypeProperty = propertyInfo;
                    if (!IsPublic(subTypeProperty))
                    {
                        // have to test on name rather than reference because instances are different
                        // depending on the type that GetProperties was called on
                        int index = initialProperties.IndexOf(p => p.Name == subTypeProperty.Name);
                        if (index == -1)
                        {
                            initialProperties.Add(subTypeProperty);
                        }
                        else
                        {
                            PropertyInfo childProperty = initialProperties[index];
                            // don't replace public child with private base
                            if (!IsPublic(childProperty))
                            {
                                // replace nonpublic properties for a child, but gotten from
                                // the parent with the one from the child
                                // the property gotten from the child will have access to private getter/setter
                                initialProperties[index] = subTypeProperty;
                            }
