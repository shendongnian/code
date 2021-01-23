    using System;
    namespace Stars
    {
      internal static class StarPattern
      {
        private static void Main()
        {
          for (int i = 0; i < 5; i++)
          {
            for (int j = 0; j < 5; j++)
            {
              Console.Write((i%4 == 0) | (j%4 == 0) ? '*' : ' ');
            }
            Console.WriteLine();
          }
        }
      }
    }
