    class Validator:Component, ISupportInitialize
    {
        // fake props
        public string Foo { get; set; }
        public int Bar  { get; set; }
        public event ValidatingEventHandler Validating;
        public delegate void ValidatingEventHandler(object sender, EventArgs e);
        public event ValidatedEventHandler Validated;
        public delegate void ValidatedEventHandler(object sender, EventArgs e);
        public Validator(string foo, int bar) 
        { 
        }
        public Validator()
        {
        }
        // ISupportInitialize methods
        public void BeginInit()
        { 
        }
        public void EndInit()
        {
        }
    }
