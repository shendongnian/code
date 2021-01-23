    public void SetProperties(object source, object target)
    {
        var contactType = target.GetType();
        foreach (var prop in source.GetType().GetProperties())
        {
            var propGetter = prop.GetGetMethod();
            var propSetter = contactType.GetProperty(prop.Name).GetSetMethod();
            var valueToSet = propGetter.Invoke(source, null);
            propSetter.Invoke(target, new[] { valueToSet });
        }
    }
