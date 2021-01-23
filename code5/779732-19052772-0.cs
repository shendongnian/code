    public class MyClass {
    
        public int Value { get; private set; }
    
        public MyClass With(int i) {
            Value = i;
            return this;
        }
    }
    
    MyClass my = new MyClass().With(5);    // Old-school
    MyClass my1 = new MyClass { }.With(6); // Kind of funky looking, but okay.
    MyClass my2 = new MyClass.With(4);     // This looks just like a static method call except for the new
