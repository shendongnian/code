    public class MyTestClass : IUseFixture<WatinFixture>, IDisposable
    {
        private WatinFixture _data;
    
        public void SetFixture(WatinFixture data)
        {
            _data = data;
            Console.WriteLine("setting data for test");
        }
        public MyTestClass()
        {
            Console.WriteLine("in constructor of MyTestClass");
        }
    
        [Fact]
        public void Fact1()
        {
            Console.WriteLine("in fact1. IE is '{0}'", _data.ReferenceToIE);
            // use _data.ReferenceToIE here
        }
    
        [Fact]
        public void Fact2()
        {
            Console.WriteLine("in fact2. IE is '{0}'", _data.ReferenceToIE);
            // use _data.ReferenceToIE here
        }
        public void Dispose()
        {
            Console.WriteLine("in Dispose of MyTestClass");
        }
    }
    
    public class WatinFixture : IDisposable
    {
        public string ReferenceToIE = null;
    
        public WatinFixture()
        {
            // start IE here
            Console.WriteLine("Starting IE ...");
            ReferenceToIE = "If you see this string - then browser reference is not empty.";
        }
    
        public void Dispose()
        {
            // close IE here
            Console.WriteLine("Closing IE ...");
            ReferenceToIE = null;
            }
        }
