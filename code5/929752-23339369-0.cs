    public class IsOfflineSpecification : ISpecification<Device>
    {
        private readonly TimeSpan limit;
    
        public IsOfflineSpecification(TimeSpan limit)
        {
            this.limit = limit;
        }
    
        public IsSatisfiedBy(Device candidate)
        {
            // Compare candidate with limit here,
            // and return the appropriate answer (true/false)
        }
    }
