    class Foo1
    {
        public int A {get; set;}
        public Bar B {get; set;}
        public List<Baz> C {get; set;}
        public double D {get; set;}
    
        public void Decode(object[,] data, int rowNumber)
        {
            this.A = (int)data[rowNumber, 0];
            //this.B = new Bar(); perhaps
            this.B.Decode(data, rowNumber);
            // etc.
        }
    }
