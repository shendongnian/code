    public class MyAttribute : Attribute
    {
        public MyAttribute(string a, string b)
        {
            this.a = a;
            this.b = b;
        }
        private string a,b;
    }
    [My("foo", "bar")]
    class WithAttribute
    {
    }
