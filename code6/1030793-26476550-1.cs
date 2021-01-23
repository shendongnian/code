    public class FullDogBowl
    {
        public int DogId { get; set; }
        public int BowlId { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
    
    var dogBowl = db.Select<FullDogBowl>(db
        .From<Dog>()
        .Join<Dog, DogBowl>((d, db) => d.Id == db.DogId)
        .Join<DogBowl, Bowl>((db, b) => db.BowlId == b.Id)
        .Where<Dog>(d => d.Id == 5))
        .ToList();
