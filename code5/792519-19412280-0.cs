    public class MyClass : IDisposable
    {
       // Limit to 10 instances
       Semaphore m_sem = new Semaphore(10, 10, "SharedName");
       private readonly GCHandle semHandle = GCHandle.Alloc(m_sem);
       public MyClass()
       {
         if(!m_sem.WaitOne(0))
         {
           throw new Exception("No instances free");
         }
       }
    
       void IDisposable.Dispose()
       {
         semHandle.Free();
         m_sem.Release();
       }
    }
