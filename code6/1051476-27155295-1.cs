    using System.Reflection;
    var modelStateProperties = typeof(MyModel).GetProperties().Where(p => p.Name == ModelState.Keys.Any(k => k == p.Name));
    foreach (var property in modelStateProperties)
    {
        // Found properties with errors in them
        var attrs = properties.GetCustomAttributes();
        // attrs now has the list of attributes, i.e., Required, StringLength, etc.
    }
