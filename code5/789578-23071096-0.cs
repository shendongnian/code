        class Program
        {
           static void Main(string[] args)
           {
            var myArr = new int[5] { 1, 2, 3, 4, 5 };
            Array.Resize(ref myArr, 10);
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, myArr[i]);
            }
            Console.ReadLine();
        }
    }
