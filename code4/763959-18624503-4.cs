    class Check
    {
         public static void Main()
         {         
                  List<int> arr1 = List<int>int[] { 1, 2, 3 };
                  Console.WriteLine("The Number That Left Us Is");
                  Random rnd = new Random();
                  int r = rnd.Next(arr1.Length);
                  int Left = (arr1[r]);
                  arr1.RemoveAt(r);
                  Console.WriteLine(Left);
                  SomeFunctionThatTakesAnArrayAsAnArgument(arr.ToArray());
          }
     }
