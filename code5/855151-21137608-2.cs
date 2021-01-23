        public class TokenStream
        {
        }
        public class SomeClass
        {            
            public Func<TokenStream> Plumb()
            {
                // I'm returning a function that returns a new TokenStream for whoever calls it
                return () => new TokenStream();
            }
        }
        static void Main(string[] args)
        {
            var someClass = new SomeClass();
            TokenStream stream = someClass.Plumb()(); // note double brackets
        }
