        void EnableAllEventSources()
        {
            foreach (var es in GetEventSourceNamesFromAssembly(GetType().Assembly);)
                _session.EnableProvider(es);
        }
        IEnumerable<string> GetEventSourceNamesFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => t.BaseType == (typeof(EventSource)))
                .Select(t => {
                    var attribute = Attribute.GetCustomAttribute(t, typeof(EventSourceAttribute));
                    return ((EventSourceAttribute)attribute).Name;
                });
        }
