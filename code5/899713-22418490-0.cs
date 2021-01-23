    // user invoked "foo -format json -url www.google.com
    // your code does something like:
    var args = new[] { "format", "url" };
    var matchingMethods = typeof(SomeType).Assembly.GetTypes()
        .Where(t => typeof(ICommand).IsAssignableFrom(t))
        .SelectMany(t => t.GetMethods())
        .Where(m => StringComparer.OrdinalIgnoreCase.Equals(m.Name, "foo"))
        .Where(m => {
            var parameters = m.GetParameters();
            var isValid = parameters.All(p => p.IsOptional || args.Contains(p.Name))
                && args.All(a => parameters.Any(p.Name == a));
            return isValid;
        })
        .ToArray();
