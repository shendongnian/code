    public Appointment(object anonymousType)
    {
        foreach (var p in anonymousType.GetType().GetProperties())
        {
            var value = p.GetValue(anonymousType);
            if (p.PropertyType == typeof(Guid))
            {
                // Type is Guid, must be Id
                base.Id = (Guid)value;
                Attributes["opportunityid"] = base.Id;
            }
            else if (p.Name == "FormattedValues")
            {
                // Add Support for FormattedValues
                FormattedValues.AddRange((FormattedValueCollection)value);
            }
            else
            {
                Attributes[p.Name.ToLower()] = value;
            }
        }
    }
