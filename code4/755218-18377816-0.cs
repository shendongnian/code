    public class Language
    {
        public static Language Instance { get; private set; }
        static Language() { Instance = new Language(); }
        private Language() { Name = "Name"; }
    
        public string Name {get;private set;}
    }
