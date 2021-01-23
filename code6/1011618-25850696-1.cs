    public Cache()
    {
		if (typeof(TIndex) == typeof(string))
		{
			this._cache = new Dictionary<TIndex, TItem>((IEqualityComparer<TIndex>)StringComparer.CurrentCultureIgnoreCase);
		}
		else
		{
			this._cache = new Dictionary<TIndex, TItem>();
		}
    }
