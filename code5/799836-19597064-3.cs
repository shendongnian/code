      public struct check
      {
         public int[] x;
         public static explicit operator check(check2 c2)
         {
            return new check() { x = new int[3] { c2.x1, c2.x2, c2.x3 } };
         }
      }
