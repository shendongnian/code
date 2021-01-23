    namespace Models
    {
        public class Residents
        {
            public int ResidentID { get; set; }
            public string PFName { get; set; }
            public string PLName { get; set; }
            //...
        }
        public class Logs
        {
            public int LogID { get; set; }
            public int ResidentID { get; set; }
            public string Comments { get; set; }
            //...
        }
    }
