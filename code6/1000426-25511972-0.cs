    public class Species : ISpecies
    {
        public string database { get; set; }
        public string genus { get; set; }
        public string binomialName { get; set; }
    }
    
    var monosiga = new Species() {
        database = "monosiga",
        genus = "Choanoflagellatea",
        binomialName = "Monosiga_brevicollis"
    }
    
    var speciesDict = new Dictionary<string, ISpecies>()
    
    speciesDict["Monosiga Whatever"] = monosiga;
