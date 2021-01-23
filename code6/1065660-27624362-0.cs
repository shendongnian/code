    public Appointment(object anonymousType)
    {
        foreach (var p in anonymousType.GetType().GetProperties())
        {
            if (p.PropertyType == typeof(Guid)) 
            {
                // Type is Guid, must be Id
                base.Id = (Guid)p.GetValue(anonymousType);
                Attributes["activityid"] = base.Id;
            }
            else
            {
                Attributes[p.Name.ToLower()] = p.GetValue(anonymousType);
            }
        }
    }
