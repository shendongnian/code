	public List<MovieData> getAllMoviesSorted(string column)
	{
		List<MovieData> movieData = db.GetAllData();
		var parameter = Expression.Parameter(typeof(MovieData));
		var lambda = Expression.Lambda(
						Expression.PropertyOrField(parameter, column),
						parameter);
		return movieData
				.AsQueryable()
				.OrderBy(lambda)
				.ToList();
	}
