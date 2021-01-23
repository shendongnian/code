    public Connection Connect()
    {
        if (this._connection == null)
        {
            this._connection == new Connection();
            return this._connection;
        }
        else
        {
            //References _connection's ExpensiveNativeConnection but can't dispose it.
            return _connection.MakeUnDisposableConnectionCopy();
        }
    }
