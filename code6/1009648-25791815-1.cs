    public class MyClass
    {
        public bool MyBool {get; set;}
        public Color MyBoolColor { get { return this.MyBool ? Colors.Green : Colors.Red; }
    }
