    /// <summary>
    /// Adds a <see cref="JsonProperty"/> object.
    /// </summary>
    /// <param name="property">The property to add to the collection.</param>
    public void AddProperty(JsonProperty property)
    {
        if (Contains(property.PropertyName))
        {
            // don't overwrite existing property with ignored property
            if (property.Ignored)
                return;
            JsonProperty existingProperty = this[property.PropertyName];
            bool duplicateProperty = true;
            if (existingProperty.Ignored)
            {
                // remove ignored property so it can be replaced in collection
                Remove(existingProperty);
                duplicateProperty = false;
            }
            else
            {
                if (property.DeclaringType != null && existingProperty.DeclaringType != null)
                {
                    if (property.DeclaringType.IsSubclassOf(existingProperty.DeclaringType))
                    {
                        // current property is on a derived class and hides the existing
                        Remove(existingProperty);
                        duplicateProperty = false;
                    }
                    if (existingProperty.DeclaringType.IsSubclassOf(property.DeclaringType))
                    {
                        // current property is hidden by the existing so don't add it
                        return;
                    }
                }
            }
            if (duplicateProperty)
                throw new JsonSerializationException("A member with the name '{0}' already exists on '{1}'. Use the JsonPropertyAttribute to specify another name.".FormatWith(CultureInfo.InvariantCulture, property.PropertyName, _type));
        }
        Add(property);
    }
