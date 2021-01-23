    public class Main
    {
        public string Name { get; set; }
        public List<Info> Info { get; set; }
        public string Info1 { 
            get {
                return Info == null || Info.Count == 0 ? "" 
                    : Info.Last().Info1; 
            } 
        }
        public string Info2
        {
            get
            {
                return Info == null || Info.Count == 0 ? ""
                    : Info.Last().Info2;
            }
        }
    }
