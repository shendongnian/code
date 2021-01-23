    public class PersonViewModel
    {
        public int Id { get; set; }
        public string LastName{get;set;}
        public int NationalityId { get; set; }
        public IEnumerable<Nationality> Nationalities {get;set;}
    }
