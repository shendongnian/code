        public IEnumerable<MovieData> Get(string searchstr)
        {
            if (MovieRepository != null)
            {
                var query =
                    from movie in MovieRepository
                    where
                        (movie.Title != null && movie.Title.Contains(searchstr)) ||
                        (movie.Genre != null && movie.Genre.Contains(searchstr)) ||
                        (movie.Classification != null && movie.Classification.Contains(searchstr)) ||
                        (movie.Cast != null && movie.Cast.Contains(searchstr)) ||
                        (movie.Rating.ToString() != null && movie.Rating.ToString().Contains(searchstr)) ||
                        (movie.ReleaseDate.ToString() != null && movie.ReleaseDate.ToString().Contains(searchstr))
                    select movie;
                return query.AsEnumerable();
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
