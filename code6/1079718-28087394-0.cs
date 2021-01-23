    public class Ingredient
    {
        public string Ingredient_id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Energie { get; set; }
        public string Vetten { get; set; }
        public string VerzadigdeVetten { get; set; }
        public string KoolHydraten { get; set; }
        public string Eiwitten { get; set; }
    }
    
    public class Benodigdheden
    {
        public string Hoeveelheid { get; set; }
        public string Eenheid { get; set; }
        public Ingredient Ingredient { get; set; }
    }
    
    public class RootObject
    {
        public string ReceptId { get; set; }
        public string Naam { get; set; }
        public string GramPerPersoon { get; set; }
        public string Type { get; set; }
        public List<string> Instructies { get; set; }
        public List<Benodigdheden> Benodigdheden { get; set; }
    }
