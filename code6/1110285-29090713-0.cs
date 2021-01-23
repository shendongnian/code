    public class ArrayTest
    {
        public static void Main()
        {
            // initialize array
            int[] myArray;
            Console.WriteLine("Enter size of an Array");
            int arrayVariable = Convert.ToInt32(Console.ReadLine());
            myArray = new int[arrayVariable];
            Console.WriteLine("Element at index {0}", arrayVariable);
            Console.WriteLine("Enter elements of Array");
            for (int i = 0; i < arrayVariable; i++)
            {
                string input = Console.ReadLine(); 
                int result;
                if(int.TryParse(input, out result))
                {
                    myArray[i] = result;
                }  
                else 
                {
                     i--;
                     Console.WriteLine("Invalid input format");  
                } 
            }
            for (int i = 0; i < arrayVariable; i++)// Display Array Elements
            {
                Console.WriteLine("Element at index {0} {1}: ", i, myArray[i]);
            }
        }
    }
