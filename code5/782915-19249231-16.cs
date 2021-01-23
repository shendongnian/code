    public class PersonEditModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FavouriteTeam { get; set; }
        public IEnumerable<SelectListItem> Teams {get;set;}
    }
