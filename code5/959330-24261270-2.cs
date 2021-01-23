    class Program
    {
        public class FiniteObjectPoolContext<T>: IDisposable
        {
            FiniteObjectPool<T> m_Pool = new FiniteObjectPool<T>();
            public T Value { get; set; }
            public FiniteObjectPoolContext(FiniteObjectPool<T> pool)
            {
                m_Pool = pool;
                Value = pool.GetObject(); //take an object out - this will block if none is available
            }
            public void Dispose()
            {
                m_Pool.PutObject(Value); //put the object back because this context is finished
            }
        }
        static void Main(string[] args)
        {
            FiniteObjectPool<int> pool = new FiniteObjectPool<int>();
            for (int i = 0; i < 10; i++)
            {
                pool.PutObject(i);
            }
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                int id = i;
                tasks.Add(Task.Run(() =>
                    {
                        Console.WriteLine("Running task " + id);
                        using (var con = new FiniteObjectPoolContext<int>(pool))
                        {
                            Console.WriteLine("Task " + id + " got object from pool: " + con.Value);
                            System.Threading.Thread.Sleep(5000);
                            Console.WriteLine("Task " + id + " is finished with pool object: " + con.Value);
                        }
                    }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
