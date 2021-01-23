    var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
        var assembliesResolver = _config.Services.GetAssembliesResolver();
        var controllerResolver = _config.Services.GetHttpControllerTypeResolver();
        var controllerTypes = controllerResolver.GetControllerTypes(assembliesResolver);
        foreach (var cType in controllerTypes)
        {
            var segments = cType.Namespace.Split(Type.Delimiter);
            var controllerName = cType.Name.Remove(cType.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
            var controllerKey = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", segments[segments.Length - 1], controllerName);
            if (!dictionary.Keys.Contains(controllerKey))
            {
                dictionary[controllerKey] = new HttpControllerDescriptor(_config, cType.Name, cType);
            }
        }
