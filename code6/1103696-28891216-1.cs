            var stringToSplit = string.Empty;
            if (source == null)
            {
                stringToSplit = NullString;
            }
            else if (string.IsNullOrEmpty(property))
            {
                stringToSplit = source.ToString();
            }
            else
            {
                Type type = source.GetType();
                var propertyInfo = type.GetProperty(property);
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(source);
                    stringToSplit = propertyValue != null ? propertyValue.ToString() : NullString;
                }
                else
                {
                    stringToSplit = NullString;
                }
            }
