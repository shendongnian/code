    if (typeof(T).IsClass)
    {
        this.GetType()
            .GetMethod("Foo", System.Reflection.BindingFlags.Instance |
                              System.Reflection.BindingFlags.Public)
            .Invoke(this, new object[] { item });
    }
