    private static readonly NamedObject<T> instance;
    static NamedObject()
    {
        // TODO: Validation :)
        var attributes = typeof(T).GetCustomAttributes(typeof(NameAttribute), false);
        var firstAttribute = ((NameAttribute[]) attributes)[0];
        string name = firstAttribute.Name;
        instance = new NamedObject<T>(name);
    }
    public static NamedObject<T> Instance { get { return instance; } }
