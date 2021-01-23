	public static class Factory
	{
		public static IAccessor<TProperty> Accessor<TClass, TProperty>(TClass instance, Func<TClass, TProperty> getter, Action<TClass, TProperty> setter)
		{
			return new genAccessor<TClass, TProperty>(instance, getter, setter);
		}
	}
