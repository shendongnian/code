    public class MyAttribute : Attribute
    {
        public MyAttribute(bool b)
        {
            MustBePositive = b;
        }
        public bool MustBePositive { get; set; }
    }
