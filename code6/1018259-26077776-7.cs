	public static Delegate ConvertTo(this Delegate self, Type type)
	{
		if (type == null) { throw new ArgumentNullException("type"); }
		if (self == null) { return null; }
		
		return Delegate.Combine(
			self.GetInvocationList()
				.Select(i => Delegate.CreateDelegate(type, i.Target, i.Method))
				.ToArray());
	}
