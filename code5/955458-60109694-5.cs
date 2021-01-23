    using System;
    using System.Threading;
    
    namespace YourNamespace
    {
      public class AutoReleaseSemaphoreWrapper : IDisposable
      {
        private readonly SemaphoreSlim _semaphore;
    
        public AutoReleaseSemaphoreWrapper(SemaphoreSlim semaphore )
        {
          _semaphore = semaphore;
        }
    
        public void Dispose()
        {
          try
          {
            _semaphore.Release();
          }
          catch { }
        }
      }
    }
