    public class SearchResultModel
    {
        public int MovieHits { get; set; }
        public int PeopleHits { get; set; }
        public IList<Model.MovieDto> Movies { get; set; }
        public IList<Model.PersonDto> People { get; set; }
    }
