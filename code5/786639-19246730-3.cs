    public class MyClass : IClonable
    {
        public Color Color1;
        public MyClass(Color color)
        {
            this.Color1 = color;
        }
        public MyClass Clone()
        {
            return new MyClass(this.Color1);
        }
    }
