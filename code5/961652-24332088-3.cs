       public static bool IsNaN(double d)
       {
           // Comparisions of a NaN with another number is always false and hence both conditions will be false.
           if (d < 0d || d >= 0d) {
              return false;
           }
           return true;
       }
