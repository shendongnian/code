    class newTB : TextBox
    {
        // encoding subset to implement
        public enum NewTBEncoding
        {
            ASCII, UTF8, UTF7
        };
        // prop as enum
        private NewTBEncoding tbEnc;
        
        public NewTBEncoding tbEncoding { 
            get { return tbEnc; } 
            set {tbEnc = value; }
        }
    }
