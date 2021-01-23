    foreach (var r in container.ComponentRegistry.Registrations)
    {
        if (r.Target.Activator.LimitType.IsSubclassOf(typeof (ViewModel)))
        {
            var dump = container.ResolveComponent(r, Enumerable.Empty<Parameter>());
        }
    }
