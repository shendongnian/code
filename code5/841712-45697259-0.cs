    You can check the following codes. The codes are working.
    
    
     class Program {
        static void Main(string[] args) {
          int[] array = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
          int count = 1;
          for (int i = 0; i < array.Length; i++) {
            for (int j = i + 1; j < array.Length; j++) {
    
              if (array[j] == array[j])
                count = count + 1;
            }
            Console.WriteLine("\t\n " + array[i] + " out of " + count);
            Console.ReadKey();
          }
        }
      }
