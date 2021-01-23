    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {9,1,6,3,7,2,4};
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length;j++)
                {
                    if(arr[i]>arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
                Console.Write(arr[i]+",");
            }
                 Console.ReadLine();
        }
  
