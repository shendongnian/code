    public Int32 Solution(Int32[] A)
    {
       var seenNumbers = new HashSet<Int32>();
       var result = 0;
       for (var index = 0; index < A.Length; index++)
       {
          if (seenNumbers.Add(A[index]))
          {
             result = index;
          }
       }
       return result;
    }
