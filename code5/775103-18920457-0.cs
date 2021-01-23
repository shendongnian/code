    public static T FromXElement<T>(XElement element) where T : class, new()
    {
        T value = new T();
        foreach (var subElement in element.Elements())
        {
            var field = typeof(T).GetField(subElement.Name.LocalName);
            field.SetValue(value, (string) subElement);
        }
        return value;
    }
