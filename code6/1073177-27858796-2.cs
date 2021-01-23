    public static int GetId<T>(this T obj)
    {
        var model = obj.GetType().GetProperty("Model").GetValue(instance, null);
        return (int)(model.GetType().GetProperty("Id").GetValue(instance, null));
    }
