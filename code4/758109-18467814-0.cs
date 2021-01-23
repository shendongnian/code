    // using System.Reflection;
    // using System.Linq;
    IEnumerable<String> properties = typeof(Languages)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Select(x => x.Name);
