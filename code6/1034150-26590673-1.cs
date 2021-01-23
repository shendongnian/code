    private readonly IDictionary<Type, MethodInfo> _methods;
    public Impl() {
        var methods = this.GetType().GetMethods(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.FlattenHierarchy);
        var provide = methods
            .Where(m => m.Name.Equals("Provide", StringComparison.Ordinal) && m.GetParameters().Length == 1)
            .ToList();
        _methods = when.ToDictionary(m => m.GetParameters().First().ParameterType, m => m);
    }
    public string Provide(IParam param) {
        MethodInfo methodInfo;
        if (dictionary.TryGetValue(param.GetType(), out methodInfo)) {
            return methodInfo.Invoke(this, new object[] { param });
        }
        return "default value";
    }
