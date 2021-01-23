    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
       ...
        if (!this._isAsync || !Environment.IsWindowsVistaOrAbove)
        {
            return base.ReadAsync(buffer, offset, count, cancellationToken);
        }
        ...
        return stateObject;
    }
