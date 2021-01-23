    public IEnumerable<BasePoco> Build()
        {
            var basePoco = typeof (BasePoco);
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => entityRule.IsAssignableFrom(type) && type.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<BasePoco>();
        }
