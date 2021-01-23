    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            foreach(int i in queue)
                System.Console.WriteLine(i);
        }
    }
