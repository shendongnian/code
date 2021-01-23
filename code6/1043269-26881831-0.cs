    internal static object Clone(this object parameter)
    {
        if (parameter is IEnumerable)
            parameter = (parameter as IEnumerable).Cast<object>().ToList();
        var serializedObject = JsonConvert.SerializeObject(parameter);
        return JsonConvert.DeserializeObject(serializedObject, parameter.GetType());
    }
