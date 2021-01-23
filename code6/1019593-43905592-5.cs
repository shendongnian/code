    public class Bar : IDisposable
    {
        // ...
    }
    
    public class Foo
    {
        private Bar _barField = new Bar();
        public Bar BarProperty { get; set; } = new Bar();
        public void CleanUp()
        {
            Disposable.Dispose(() => _barField);
            Disposable.Dispose(() => BarProperty);
            var barVariable = new Bar();
            Disposable.Dispose(() => barVariable);
        }
    }
