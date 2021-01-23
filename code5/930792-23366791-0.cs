    public IEnumerable<Enumerador> GetClients<T>() where T : IEnumerador, new()
    {
        T _cli = new T();
        return _cli.Enumerar();            
    }
