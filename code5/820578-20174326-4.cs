    public class MyClass
    {
        public int number { get; set; }
        
        static public implicit operator MyClass(int value)
        {
            return new MyClass() { number = value };
        }
    }
