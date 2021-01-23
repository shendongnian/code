      public static class Permutations {
        public static BigInteger Count(int size) {
          if (size < 0)
            return 0;
    
          BigInteger result = 1;
    
          for (int i = 2; i <= size; ++i)
            result *= i;
    
          return result;
        }
    
        public static int[] Unrank(int size, BigInteger rank) {
          if (size < 0)
            throw new ArgumentOutOfRangeException("size", "size should not be negative.");
          else if (rank < 0)
            throw new ArgumentOutOfRangeException("rank", "size should not be negative.");
    
          int[] digits = new int[size];
    
          for (int digit = 2; digit <= size; ++digit) {
            BigInteger divisor = digit;
    
            digits[size - digit] = (int) (rank % divisor);
    
            if (digit < size)
              rank /= divisor;
          }
    
          int[] permutation = new int[size];
          List<int> usedDigits = new List<int>(size);
    
          for (int i = 0; i < size; ++i)
            usedDigits.Add(0);
    
          for (int i = 0; i < size; ++i) {
            int v = usedDigits.IndexOf(0, 0);
    
            for (int k = 0; k < digits[i]; ++k)
              v = usedDigits.IndexOf(0, v + 1);
    
            permutation[i] = v;
            usedDigits[v] = 1;
          }
    
          return permutation;
        }
      }
    
      ...
    
          StringBuilder Sb = new StringBuilder();
    
          String data = "Case 1 V1: A, B, C";
    
          String[] items = data.Substring("Case 1 V1:".Length).Trim().Split(',').Select(x => x.Trim()).ToArray();
    
          for (int i = 0; i < (int) Permutations.Count(items.Length); ++i) {
            if (Sb.Length > 0)
              Sb.AppendLine();
    
            Sb.Append("Case 1 V1: ");
    
            Boolean firstItem = true;
    
            foreach (int j in Permutations.Unrank(items.Length, i)) {
              if (!firstItem)
                Sb.Append(", ");
    
              firstItem = false; 
    
              Sb.Append(items[j]);
            }
          }
    
          String result = Sb.ToString();
