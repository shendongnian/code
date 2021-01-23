    public abstract class NoiseOrigin
    {
        public NoiseOrigin()
        {
            this.NoiseRecords = new Collection<NoiseRecord>();
        }
    
        public int Id { get; set; }
    
        public ICollection<NoiseRecord> NoiseRecords { get; set; }
    }
    
    public class Car : NoiseOrigin {}
    
    public class Plane : NoiseOrigin { }
    
    public class NoiseRecord
    {
        public int Id { get; set; }
    
        public int OriginId { get; set; }
        public NoiseOrigin Origin { get; set; }
    
        public double NoiseMagnitude { get; set; }
    }
