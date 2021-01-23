    public class MyType : IDisposable {
        private FileSystemWatcher _watcher;
    
        public void Dispose() {
           if(_watcher != null)
              _watcher.Dispose();
        }
    }
