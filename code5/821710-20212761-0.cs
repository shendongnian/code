    public interface IA
    {
       int x { get; }
    }
    
    class A : IA
    {
        public int x { get; set; } // nothing stopping you having a setter on the class
    }
    
    class S
    {
        private A a = new A(); // you can call the setter internally on this instance
        public IA GetA(){ return a; } // when someone gets this thy only get the getter
    }
