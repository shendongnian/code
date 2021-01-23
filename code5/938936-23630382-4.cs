    var methods = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(x => x.GetTypes())
                           .Where(x => x.IsClass && x.Namespace == ...)
                           .Select(x => new Tuple<string, IEnumerable<string>>(
                               x.Name,
                               x.GetMethods().Select(y => y.Name)));
