    public class Foo
    {
        SemaphoreSlim _lock = new SemaphoreSlim(1);
    
        public async Task Bar()
        {
            await _lock.WaitAsync();
            await BarNoLock();
            _lock.Release();
         }
    
        public async Task BarInternal()
        {
            await _lock.WaitAsync(); // no deadlock
            await BarNoLock();
            _lock.Release();
         }
         private async Task BarNoLock()
         {
             // do the work
         }
    }
