        public IEnumerable<MovieDTO> GetAllMovies()
        {
            var data = this.Data.Movies.All().Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                ReleaseDate = x.ReleaseDate,
                Rating = x.Rating,
                Duration = x.Duration,
                Director = x.Director,
                Writer = x.Writer,
                Cost = x.Cost,
                Type = x.Type
            }).OrderBy(x => x.Id).ToList();
            return data;
        }
