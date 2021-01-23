    public class Throttler<T>
    {
       private readonly long[] callTimes;
       private int cur;      
       private readonly Func<T> func;
       private readonly TimeSpan interval;
       private readonly object padlock = new object();    
       public Throttler(Func<T> func, int maxCalls, TimeSpan interval)
       {
          this.func = func;
          callTimes = new long[maxCalls];
          this.interval = interval;
          cur = 0;
       }
       public T Call()
       {
          lock (padlock)
          {
             do
             {
                long oldestCall = callTimes[(cur + 1)%callTimes.Length];
                long now = DateTime.UtcNow.Ticks;               
                if (now - oldestCall > interval.Ticks)
                {                 
                   cur = (cur + 1) % callTimes.Length;                  
                   callTimes[cur] = now;
                   return func();
                }
                int sleepTime = (int)((interval.Ticks - (now - oldestCall))/TimeSpan.TicksPerMillisecond) + 1;               
                Thread.Sleep(sleepTime);               
             } while (true);
          }
       }
    }
