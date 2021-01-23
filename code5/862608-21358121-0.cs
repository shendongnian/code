    BlockingCollection<int> bc = new BlockingCollection<int>();
    Task.Run(() => new Reader(bc).DoWork());
    Task.Run(() => new Writer(bc).DoWork());
---
    public class Reader
    {
        BlockingCollection<int> _Pipe = null;
        public Reader(BlockingCollection<int> pipe)
        {
            _Pipe = pipe;
        }
        public void DoWork()
        {
            foreach(var i in _Pipe.GetConsumingEnumerable())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("END");
        }
    }
    public class Writer
    {
        BlockingCollection<int> _Pipe = null;
        public Writer(BlockingCollection<int> pipe)
        {
            _Pipe = pipe;
        }
        public void DoWork()
        {
            for (int i = 0; i < 50; i++)
            {
                _Pipe.Add(i);
                Thread.Sleep(100);
            }
            _Pipe.CompleteAdding();
        }
    }
