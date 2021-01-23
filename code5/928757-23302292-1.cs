     public T Create<T>(object args) where T : Control, new()
     {
            T control = new T();
            var propertyValues = args.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(args));
            var controlType = typeof(Control);
            foreach (var kvp in propertyValues)
            {
                var prop = controlType.GetProperty(kvp.Key);
                prop.SetValue(control, kvp.Value);
            }
            return control;
     }
