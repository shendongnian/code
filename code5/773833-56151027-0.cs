	/// <summary>
	/// Convert the provided object into an array 
	/// with the object as its single item.
	/// </summary>
	/// <typeparam name="T">The type of the object that will 
	/// be provided and contained in the returned array.</typeparam>
	/// <param name="withSingleItem">The item which will be 
	/// contained in the return array as its single item.</param>
	/// <returns>An array with <paramref name="withSingleItem"/> 
	/// as its single item.</returns>
	public static T[] ToArray<T>(this T withSingleItem) => new[] { withSingleItem };
