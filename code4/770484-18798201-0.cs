    [System.Flags]
    enum Things { Cat = 1, Dog = 2, Mouse = 4, House = 8, Ball = 16, Music = 32 }
          
    class Program
    {
     
        static void Main()
        {
     
            var value = Things.Cat | Things.Dog;
     
            Console.WriteLine(value.ToString());
         }
    }
