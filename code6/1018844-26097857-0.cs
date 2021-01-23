    public class MyClass : IDisposable {
        // ...
        public virtual void Dispose() {
            if(stream != null) {
                stream.Dispose();
                stream = null;
            }
            if(log != null) {
                log.Dispose();
                log = null;
            }
        }
    }
