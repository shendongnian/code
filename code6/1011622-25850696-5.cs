    public Cache()
    {
		if (typeof(TIndex) == typeof(string))
		{
			this._cache = new Dictionary<TIndex, TItem>((IEqualityComparer<TIndex>)StringComparer.InvariantCultureIgnoreCase);
		}
		else
		{
			this._cache = new Dictionary<TIndex, TItem>();
		}
    }
