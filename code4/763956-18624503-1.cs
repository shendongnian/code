    class Check
    {
         public static void Main()
         {         
                  int[] arr1 = int[] { 1, 2, 3 };
                  Console.WriteLine("The Number That Left Us Is");
                  Random rnd = new Random();
                  int r = rnd.Next(arr1.Length);
                  int Left = (arr1[r]);
                  
                  int oldLength = arr1.Length;
                  arrTmp = arr1;                  
                  arr1 = new int[oldLength - 1];
                  Array.Copy(arrTmp, arr1, r);
                  Array.Copy(arrTmp, r+1, arr1, r, oldLength - r - 1);
                  Console.WriteLine(Left);
          }
     }
