     public async Task<bool> MutexWithAsync()
     {
         using (Semaphore semaphore = new Semaphore(1, 1, "My semaphore Name"))
         {
             try
             {
                 semaphore.WaitOne();
                 await DoSomething();
                 return true;
             }
             catch { return false; }
             finally { semaphore.Release(); }
         }
     }
