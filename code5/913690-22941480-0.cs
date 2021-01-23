    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Collections.Concurrent;
    
    namespace ConsoleApplication2
    {
    
      class Item
      {
        private int _value;
        public int Value
        {
          get
          {
            return _value;
          }
        }
    
        // all you need
        public Item(int i)
        {
          _value = i;
        }
      }
    
      class WorkerParameters
      {
        public ConcurrentQueue<Item> Items = new ConcurrentQueue<Item>();
      }
    
      class Worker
      {
        private Thread _thread;
        private WorkerParameters _params = new WorkerParameters();
    
        public void EnqueueItem(Item item)
        {
          _params.Items.Enqueue(item);
        }
    
        public void Start()
        {
          _thread = new Thread(new ParameterizedThreadStart(ThreadProc));
          _thread.Start();
        }
    
        public void Stop()
        {
          // build somthing to stop your thread
        }
    
        public static void ThreadProc(object threadParams)
        {
          WorkerParameters p = (WorkerParameters)threadParams;
          while (true)
          {
            while (p.Items.Count > 0)
            {
              Item item = null;
              p.Items.TryDequeue(out item);
    
              if (item != null)
              {
                // do something
              }
    
            }
            System.Threading.Thread.Sleep(50);
          }
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
    
          Worker w1 = new Worker();
          Worker w2 = new Worker();
          w1.Start();
          w2.Start();
    
          List<Item> itemsToProcess = new List<Item>();
          for (int i = 1; i < 1000; i++)
          {
            itemsToProcess.Add(new Item(i));
          }
    
          for (int i = 1; i < 1000; i++)
          {
            w1.EnqueueItem(itemsToProcess[i]);
            w2.EnqueueItem(itemsToProcess[i]);
          }
    
    
        }
      }
    }
