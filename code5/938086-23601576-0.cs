    public class Settings {
        public double Width {get;set;}
        public double Height {get;set;}
    
        public string ToJson()
        {
            return Json.Encode(this);
        }
    }
