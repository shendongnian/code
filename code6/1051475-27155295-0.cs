    using System.Reflection;
    var validationProperty = typeof(MyModel).GetProperties().FirstOrDefault(p => p.Name == ModelState.Items[p.Name]);
    if (validationProperty != null)
    {
        var isRequired = vationProperty.GetCustomAttribute<Required>() != null;
    }
