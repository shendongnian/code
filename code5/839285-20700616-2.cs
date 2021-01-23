        if (types.TryGetValue(type, out result))
        {
            return result;
        }
        else if (typeof(Base).IsAssignableFrom(type))
        {
            return SqlDbType.VarBinary;
        }
        else
        {
            // whatever, for example:
            throw new ArgumentException(type);
        }
