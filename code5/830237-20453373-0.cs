    public class SomeObject
    {
        public string x { get; set; }
        public int y { get; set; }
        private void Serialize(){}
        
        ~SomeObject() {
          Serialize();
        }
    }
