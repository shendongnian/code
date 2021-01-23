    class Model //the name of your model
    {
        //...
        public int Property { get; set; }
        public bool myProperty {
            get    
            {
                return this.Property == 2;
            }
        }
    }
