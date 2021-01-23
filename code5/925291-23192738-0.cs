    class Program
    {
       static void Main()
       {
           string numberStr = Console.ReadLine(); // "1 2 3 1 2 3 1 2 ...."
           string[] splitted = numberStr.Split(' ');
           int[] nums = new int[splitted.Length];
    
           for(int i = 0 ; i < splitted.Length ; i++)
           {
             nums[i] = int.Parse(splitted[i]);
           }
       }
    }
