	// System.Collections.Generic.Dictionary<TKey, TValue>
	[__DynamicallyInvokable]
	public TValue this[TKey key]
	{
		[__DynamicallyInvokable]
		get
		{
			int num = this.FindEntry(key);
			if (num >= 0)
			{
				return this.entries[num].value;
			}
			ThrowHelper.ThrowKeyNotFoundException();
			return default(TValue);
		}
		[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		set
		{
			this.Insert(key, value, false);
		}
	}
