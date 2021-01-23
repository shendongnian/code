    public class StreamContainer
    {
        public StreamContainer(string name, Stream contents)
        {
            if (name == null) {
                throw new ArgumentNullException("name");
            }
            if (contents == null) {
                throw new ArgumentNullException("contents");
            }
            
            this.name = name;
            this.contents = contents;
        }
        
        private readonly string name;
        
        public string Name {
            get {
                return name;
            }
        }
        
        private readonly Stream contents;
        
        public Stream Contents {
            get {
                return contents;
            }
        }
    }
