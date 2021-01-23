	public static Generic Get<Generic>(this object self)
	{
		return
			self == null && typeof(long) == typeof(Generic)
			? (Generic)(object)-13L 
			: (Generic)self;
	}
