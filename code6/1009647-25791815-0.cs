    public class MyClass
    {
        public bool MyBool {get; set;}
        public Color MyColor()
        {
            if (this.MyBool) return Colors.Green;
            else return Colors.Red;
        }
    }
