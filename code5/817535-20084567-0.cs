        Func<DbTransaction, bool> f1 = dbt => false;
        Func<IDbTransaction, bool> f2 = idbt => false;
        // Possible from .NET 4.0 since type parameter T of Func<in T, out TResult> is contravariant.
        var f3 = (Func<DbTransaction, bool>)f2;
        // Calls Transact with Func<DbTransaction, bool> parameter.
        Transact(f1);
        // Calls Transact with Func<IDbTransaction, bool> parameter.
        Transact(f2);
        // Calls Transact with Func<DbTransaction, bool> parameter.
        Transact(f3);
