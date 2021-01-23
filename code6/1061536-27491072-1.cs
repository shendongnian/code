    public virtual IEnumerable<T> GetByUsuarioId(int usuarioId)
    {
        if (!typeof(T).GetInterfaces().Contains(typeof(IAuditable))
            return null;
     
        return _dbset.FindBy(c => c.UsuarioId == usuarioId);
    }
