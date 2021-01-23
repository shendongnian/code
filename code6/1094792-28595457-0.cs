    public class Locatie
    {
        [Key]
        public int Id { get; set; }
        private String naam;
        private ICollection<float> gemiddeldeMaandTemperaturen = new List<float>();//want to map this
        private ICollection<float> totaleMaandNeerslag = new List<float>();//and this 
    // other code 
