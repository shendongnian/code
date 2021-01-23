    private static ResourceManager _resources = new ResourceManager("MyClass.myResources",
        System.Reflection.Assembly.GetExecutingAssembly());
    public static IEnumerable<string> GetLocalizedNames(this IEnumerable enumValues)
    {
        foreach(var e in enumValues)
        {
            string localizedDescription = _resources.GetString(String.Format("{0}.{1}", e.GetType(), e));
            if(String.IsNullOrEmpty(localizedDescription))
            {
                yield return e.ToString();
            }
            else
            {
                yield return localizedDescription;
            }
        }
    }
