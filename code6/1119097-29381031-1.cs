    public class Source<T> {
        public T Value { get; set; }
    }
    
    public class Destination<T> {
        public T Value { get; set; }
    }
    
    // Create the mapping
    Mapper.CreateMap(typeof(Source<>), typeof(Destination<>));
