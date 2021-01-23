    public class Program
    {
      public static int Count = 0;
      public static int MyCompare<T>(T first, second)
      {
        Count++;
        return Comparer<T>.Default.Compare(first, second);
      }
      // Update your first sort to use the new compare.
      public static void HeapSort<T>(T[] array)
      {
        HeapSort<T>(array, 0, array.Length, MyCompare);
      }
      // Now all of the rest of your original code inside of Program.
    }
