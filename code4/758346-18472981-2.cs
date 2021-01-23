    public bool Equality(byte[] a1, byte[] b1)
    {
       int i;
       if (a1.Length == b1.Length)
       {
          i = 0;
          while (i < a1.Length && (a1[i]==b1[i])) //Earlier it was a1[i]!=b1[i]
          {
              i++;
          }
          if (i == a1.Length)
          {
              return true;
          }
       }
       return false;
    }
