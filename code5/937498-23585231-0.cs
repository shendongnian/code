    public class MovieViewModel
    {
        public string Genre { get; set; }
    
        public IEnumerable<SelectListItem> GenreList
        {
            get
            {
                yield return new SelectListItem { Text = "Comedy", Value = "1" };
                yield return new SelectListItem { Text = "Drama", Value = "2" };
                yield return new SelectListItem { Text = "Documentary", Value = "3" };
            }
        }
    }
