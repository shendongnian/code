    public virtual IEnumerable<T> GetByUsuarioId(int usuarioId)
    {
        if (!typeof(T).GetInterfaces().Contains(typeof(IAuditable))
            return Enumerable.Empty<T>(); // per OffHeGoes' suggestion
     
        return _dbset.FindBy(c => c.UsuarioId == usuarioId);
    }
