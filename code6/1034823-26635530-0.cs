	/// <summary>
	///		Gets a value indicating whether this <see cref="JsonConverter"/> can read JSON.
	/// </summary>
	/// <value><c>true</c> if this <see cref="JsonConverter"/> can read JSON; otherwise, <c>false</c>.</value>
	public override bool CanRead
	{
		get { return _map.Count > 0; }
	}
