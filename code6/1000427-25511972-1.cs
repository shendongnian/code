    public class Species : ISpecies
    {
        public string database { get; set; }
        public string genus { get; set; }
        public string binomialName { get; set; }
    }
    
    var speciesList = new List<ISpecies>()
    var monosiga = new Species() {
        database = "monosiga",
        genus = "Choanoflagellatea",
        binomialName = "Monosiga_brevicollis"
    }
       
    speciesList.Add(monosiga);
