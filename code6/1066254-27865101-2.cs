    public sealed class MovieViewModel
    {
        public MovieViewModel(Movie movie)
        {
            _thumbnailId = movie.ThumbnailId;
            Id = movie.Id;
            Name = movie.Name;
            // copy other property values across
        }
        readonly int _thumbnailId;
        public int Id { get; private set; }
        public string Name { get; private set; }
        // other movie properties, all with public getters and private setters
        public byte[] Thumbnail { get; private set; }  // Will flesh this out later!
    }
