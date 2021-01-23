    public class Class1
    {
        public String X = String.Format("{0}", "Hello");
        public String Y = X.Substring(1);  //Error: A field initializer cannot reference the non-static field, method, or property 'Namespace.Class1.X'
    }
