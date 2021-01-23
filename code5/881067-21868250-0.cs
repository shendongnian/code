    public class Processor
    {
        public ICollection<object> Process(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            // do stuff
            return new Collection<object>();
        }
    }
