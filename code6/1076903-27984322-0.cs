    public IEnumerable<IMyInterface> GetClasses(AppDomain CurrentDomain)
        {
            var _type = typeof(IMyInterface);
            var _types = CurrentDomain.GetAssemblies().SelectMany(_s => _s.GetTypes()).Where(i => _type.IsAssignableFrom(i) && !i.IsInterface);
            List<IMyInterface> _classes = new List<IMyInterface>();
            foreach (var _instance in _types)
            {
                _classes.Add((IMyInterface)Activator.CreateInstance(_instance));
            }
            return _classes;
        }
