    public static IList MakeList(object itemOftype)
    {
        Type listType = typeof(List<>).MakeGenericType(itemOfType.GetType());
        return (IList) Activator.CreateInstance(listType);
    }
