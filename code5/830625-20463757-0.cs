	interface IHasPosition
	{
		float X { get; }
		float Y { get; }
	}
	interface IHasValue<T>
	{
		T Value { get; }
	}
	interface IPositionValue<T> : IHasPosition, IHasValue<T>
	{ }
