    /// <summary>
	/// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
	/// </summary>
	/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
	/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
	/// <param name="pageSize">The maximum size of any individual subset.</param>
	/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
	/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
	public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
			: this(superset.AsQueryable<T>(), pageNumber, pageSize)
		{
		}
