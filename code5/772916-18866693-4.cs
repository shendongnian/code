    void WritePropertyNames<T>(IPropertyListOwner<T> owner)
    {
        foreach (var property in owner.Properties)
        {
            Console.WriteLine(property.Name);
        }
    }
