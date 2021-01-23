    public static T GetFromAttribute<T>(string attributeName)
    {
        Type type = typeof(T);
        return (T)Enum.Parse(typeof(T), type.GetRuntimeFields().FirstOrDefault(
          x => (x.CustomAttributes.Count() > 0 && (x.CustomAttributes.FirstOrDefault().ConstructorArguments.FirstOrDefault().Value as string).Equals(attributeName))).Name);
    }
