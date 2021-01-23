    class MyClass
    {
    public class MySubClass
    {
        public int One { private set; get; }
        public int Two { private set; get; }
        public int Three { private set; get; }
        public MySubClass(int one, int two, int three)
        {
            this.One = one;
            this.Two = two;
            this.Three = three;
        }
       
    };
    public MySubClass ObjectMySubClass { private set; get; }
    private void SetSomething()
    {
        this.ObjectMySubClass = new MySubClass(1, 2, 3);
    }
    }
