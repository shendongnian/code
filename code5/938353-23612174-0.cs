    public interface I {
        string S { get; set; }
    }
    class C : I {
        public C() {
            this.S = "Hello World"; 
            //compile error: explicit implementation not accessible
        }
    
        string I.S { get; set; }
    }
