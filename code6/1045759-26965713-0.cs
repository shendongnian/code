    class Program
        {
            static void Main(string[] args)
            {
            var num = new int[1000];
            var rnd = new Random();
            Console.WriteLine("Before Sorting...");
            for (var i = 0; i < 1000; i++)
            {
                num[i] = rnd.Next(1000);
                Console.WriteLine(num[i]);
                 //Doesn't do anything here
                //Console.WriteLine(num[i] = rnd.Next(1000));
            }
            Console.WriteLine("After Sorting...");
            Array.Sort(num);
            for (var i = 0; i < 1000; i++)
            {
                
                Console.WriteLine(num[i]);
                //Doesn't do anything here
                //Console.WriteLine(num[i] = rnd.Next(1000));
            }
            Console.ReadLine();
        }
    }
