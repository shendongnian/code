    public string DbSet(EntitySet entitySet) {
        return string.Format(
            CultureInfo.InvariantCulture,
            "public virtual DbSet<{0}> {1} {{ get; set; }}",
            _typeMapper.GetTypeName(entitySet.ElementType),
            _code.Escape(entitySet));
    }
