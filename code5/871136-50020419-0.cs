    var result = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .GroupBy(x => x.DeclaringType.Name)
                .Select(x => new { Controller = x.Key, Actions = x.Select(s => s.Name).ToList() })
                .ToList();
