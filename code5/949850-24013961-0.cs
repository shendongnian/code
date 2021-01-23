	/// <summary>
	///     Define your ServiceStack web service request (i.e. Request DTO).
	/// </summary>
	/// <remarks>The route is defined here rather than in the AppHost.</remarks>
	[Api("GET or DELETE a single movie by Id. Use POST to create a new LifetouchRespRate and PUT to update it")]
	[Route("/movies", "POST,PUT,PATCH,DELETE")]
	[Route("/movies/{Id}")]
	public class Movie : IReturn<MovieResponse>
	{
		/// <summary>
		///     Initializes a new instance of the movie.
		/// </summary>
		public Movie()
		{
			this.Genres = new List<string>();
		}
		/// <summary>
		///     Gets or sets the id of the movie. The id will be automatically incremented when added.
		/// </summary>
		[AutoIncrement]
		public int Id { get; set; }
		public string ImdbId { get; set; }
		public string Title { get; set; }
		public decimal Rating { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string TagLine { get; set; }
		public List<string> Genres { get; set; }
	}
	/// <summary>
	///     Define your ServiceStack web service response (i.e. Response DTO).
	/// </summary>
	public class MovieResponse
	{
		/// <summary>
		///     Gets or sets the movie.
		/// </summary>
		public Movie Movie { get; set; }
	}
	/// <summary>
	///     Create your ServiceStack restful web service implementation.
	/// </summary>
	public class MovieService : Service
	{
		/// <summary>
		///     GET /movies/{Id}
		/// </summary>
		public MovieResponse Get(Movie movie)
		{
			return new MovieResponse
				       {
					       Movie = Db.Id<Movie>(movie.Id),
				       };
		}
		/// <summary>
		///     POST /movies
		///     returns HTTP Response =>
		///     201 Created
		///     Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
		///     {newMovie DTO in [xml|json|jsv|etc]}
		/// </summary>
		public object Post(Movie movie)
		{
			Db.Insert(movie);
			var newMovieId = Db.GetLastInsertId();
			var newMovie = new MovieResponse
				               {
					               Movie = Db.Id<Movie>(newMovieId),
				               };
			return new HttpResult(newMovie)
				       {
					       StatusCode = HttpStatusCode.Created,
					       Headers =
						       {
							       {HttpHeaders.Location, base.Request.AbsoluteUri.CombineWith(newMovieId.ToString())}
						       }
				       };			
		}
