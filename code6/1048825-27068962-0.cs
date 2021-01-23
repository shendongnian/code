    public class SimulationParameter : IAggregateRoot
    {
        public SimulationParameter()
        {
        }
        public String SimulationId { get; set; }
        [ForeignKey("Study")]
        public int StudyId { get; set; }
        public Study Study { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }            
    }
