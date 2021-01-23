    public DbEntityEntry<T> Entry<T>(T entity) 
        where T : class
    {
        ConstructorInfo constructor = null;
    
        try
        {
            // Binding flags exclude public constructors.
            constructor = typeof(DbEntityEntry<T>)
                .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, 
                new Type[] { typeof(InternalEntityEntry) }, null);
        }
        catch (Exception exception)
        {
            throw new Exception("Error Finding Constructor", exception);
        }
    
        if (constructor == null) // || constructor.IsAssembly)
            // Also exclude internal constructors ...  note, were including for this example
            throw new Exception(string.Format("A private or " +
                    "protected constructor is missing for '{0}'.", typeof(DbEntityEntry<T>).Name));
    
        return (DbEntityEntry<T>)constructor.Invoke(new object[] { entity });
    }
