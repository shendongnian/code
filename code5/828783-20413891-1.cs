	interface IReadableList<out T> {
		T this[int index] { get; }
	}
	interface IWritableList<in T> {
		T this[int index] { set; }
	}
	interface IMutableList<T>: IReadableList<T>, IWritableList<T> {
		new T this[int index] { get; set; }
	}
