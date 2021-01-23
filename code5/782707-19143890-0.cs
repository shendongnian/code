    class Program
    {
        static Random rnd=new Random();
        static int functionCall()
        {
            return rnd.Next(1, 1000);
        }
        static void Main(string[] args)
        {
            var original=new Dictionary<int,int>(10);
            for(int i=0; i<10; i++)
            {
                original.Add(functionCall(), i);
            }
            // original:
            //
            // [646, 0]
            // [130, 1]
            // [622, 2]
            // [454, 3]
            // ...
            // [658, 9]
            var sorted=new SortedList<int, int>(original);
            // sorted:
            //
            // [ 90, 5]
            // [130, 1]
            // [404, 7]
            // [454, 3]
            // ...
            // [756, 8]
        }
    }
