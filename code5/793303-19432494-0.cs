    public class Names 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tip {
            get
            {
                return Name == "me" ? "this is me" : "";
            }
        }
    }
