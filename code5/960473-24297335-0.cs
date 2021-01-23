    public class MyTestClass : IUseFixture<WatinFixture>
    {
        private WatinFixture _data;
    
        public void SetFixture(WatinFixture data)
        {
            _data = data;
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
