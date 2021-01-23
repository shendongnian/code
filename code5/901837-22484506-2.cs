      class Program
      {
        static ConcurrentQueue<int> _centralQueue = new ConcurrentQueue<int>();
        static AutoResetEvent _signaller = new AutoResetEvent(false);
    
        static void Main(string[] args)
        {
          Task.Factory.StartNew(() => Producer1Thread());
          Task.Factory.StartNew(() => Producer2Thread());
    
          var neverEndingConsumer = Task.Factory.StartNew(() => ConsumerThread());
          neverEndingConsumer.Wait();
        }
    
        static void Producer1Thread()
        {
          for (int i=2000; i<3000; i++)
          {
            _centralQueue.Enqueue(i);
            _signaller.Set();          
            Thread.Sleep(8);
          }
        }
    
        static void Producer2Thread()
        {
          for (int i = 0; i < 1000; i++)
          {
            _centralQueue.Enqueue(i);
            _signaller.Set();
            Thread.Sleep(10);
          }
        }
    
        static void ConsumerThread()
        {
          while (true)
          {
            if (_centralQueue.IsEmpty)
            {
              _signaller.WaitOne();
            }
            int number;
            if (_centralQueue.TryDequeue(out number))
            {
              Console.WriteLine(number);
            }        
          }
        }
      }
