    static void Main(string[] args)
        {  
            int[] A = { 3, -12, 6, 9, -7, -13, 19, 35, -8, -11, 15, 27,-1 };    
            DisplayArray(A);
            Console.WriteLine("\n=====================\n");
            Console.WriteLine("Swapping first and last element");
            SwapFirstAndLast(A);
            DisplayArray(A);
            //pause
            Console.ReadLine();
    
        }
    
        static void SwapFirstAndLast(int[] array)
           {
               //Equal than yours
           }
    
        //method to display array
        static void DisplayArray(int[] array)
        {
            Console.WriteLine("\n===========================\n");
            Console.WriteLine(string.Join(",", array);
            Console.WriteLine("\n===========================\n");
        }
