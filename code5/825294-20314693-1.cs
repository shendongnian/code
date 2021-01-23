	List<Media> MediaList = new List<Media>();
	List<Movie> MovieList = new List<Movie>();
	MovieList.Add(new Movie());
	MovieList.Add(new Movie());
	MovieList.Add(new Movie());
	MediaList.AddRange(MovieList);
	MediaList.AddRange(MovieList.Cast<Media>().ToList());
