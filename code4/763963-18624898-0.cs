    static void Main(string[] args)
    {
           int[] arr1 = new int[] { 1, 2, 3 };
          Console.WriteLine("The Number That Left Us Is");
          Random rnd = new Random();
          int r = rnd.Next(arr1.Length);
          // Create a new array except the item in the specific location
          arr1 = arr1.Except(new int[]{arr1[r]}).ToArray();
          int Left = (arr1[r]);
          Console.WriteLine(Left);
    }
