    public class Foo : IDisposable
    {
        private readonly WordprocessingDocument _package;
        public Foo()
        {
            _package = GetPackage(docName); // implemented as above
        }
        public void Method1()
        {
           // use _package without `using` block
        }
   
        public void Method2()
        {
           // use _package without `using` block
        }
        public void Dispose()
        {
            if (_package != null)
                _package.Dispose();
        }
    }
