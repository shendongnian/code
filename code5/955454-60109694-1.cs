    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace YourNamespace
    {
      public static class SemaphorSlimExtensions
      {
        public static IDisposable LockSync(this SemaphoreSlim semaphore)
        {
          if (semaphore == null)
            throw new ArgumentNullException(nameof(Semaphore));
    
          var wrapper = new AutoReleaseSemaphoreWrapper(semaphore);
          semaphore.Wait();
          return wrapper;
        }
    
        public static async Task<IDisposable> LockAsync(this SemaphoreSlim semaphore)
        {
          if (semaphore == null)
            throw new ArgumentNullException(nameof(Semaphore));
    
          var wrapper = new AutoReleaseSemaphoreWrapper(semaphore);
          await semaphore.WaitAsync();
          return wrapper;
        }
      }
    }
