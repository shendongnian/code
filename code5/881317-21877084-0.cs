    public class CheckboxlistViewModel
    {
        public int UserId { get; set; }
        public string JokeTitle { get; set; }
        public string JokeText { get; set; }
        public List<Categorie> categories { get; set; }
    }
    public class Categorie
    {
        public string Category { get; set; }
        public bool IsSelected { get; set; }
    }
