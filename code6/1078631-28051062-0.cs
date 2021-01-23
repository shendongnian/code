    /// <summary>
    /// Throws any exception.
    /// </summary>
    /// <typeparam name="TException">Type of the exception to throw </typeparam>
    /// <exception>Thrown when
    ///     <cref>TException</cref> whatever...
    /// </exception>    
    public static void Throw<TException>() where TException : Exception
    {
        throw (TException)Activator.CreateInstance(typeof(TException));
    }
