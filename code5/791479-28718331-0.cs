    public override DataTable GetSchema (string collectionName)
    {
        return GetSchema (collectionName, null);
    }
    public override DataTable GetSchema (string collectionName, string [] restrictionValues)
    {
        if (State == ConnectionState.Closed)
            throw ExceptionHelper.ConnectionClosed ();
        return GetSchema (collectionName, null);
    }
