            public static object GetField(object listItem, string fieldName)
            {
                return listItem.GetType()
                   .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                   .GetValue(listItem);
            }
