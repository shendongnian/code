      public bool Equality(byte[] a1, byte[] b1)
        {
           int i = 0;
           if (a1.Length == b1.Length)
           {
              while ((i < a1.Length) && (a1[i]==b1[i]))
              {
                  i++ ;
               }
            }
    
            return i == a1.Length;
        }
