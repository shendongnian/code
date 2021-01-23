    public static T GetMyClass<T>(this ListControl data) where T : myClass, new()
    {
        var value = data.SelectedValue.ToNullableInt();
        if (value.HasValue)
        {
            return new T() { Id = value.Value };
        }
        return null;
    }
