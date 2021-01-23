    public sealed class TestClass : IDisposable {
        private SomeDisposable items = new SomeDisposable();
        public SomeDisposable Items { get { return items; } }
        public void Dispose() {
            if(items != null) {
                items.Dispose();
                items = null;
            }
        }
    }
