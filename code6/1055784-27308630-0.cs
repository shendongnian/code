    class Program
        {
            static void Main(string[] args)
            {
                const int CAPACITY = 10;
                Queue<int> queue = new Queue<int>(CAPACITY);
                for (int i = 0; i < 50; i++)
                {
                    if (queue.Count == CAPACITY)
                        queue.Dequeue();
                    queue.Enqueue(i);
                }
                queue.ToArray();
                Console.WriteLine(queue.Count);
                Console.ReadKey();
            }
    
        }
