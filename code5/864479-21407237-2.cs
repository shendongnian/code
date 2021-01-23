    public string calcXor(String a, String b) {
      int len = (a.Length < b.Length) ? a.Length : b.Length;
    
      StringBuilder Sb = new StringBuilder();
    
      for (int i = 0; i < len; ++i) 
        // Sb.Append(CharToBinary(a[i] ^ b[i])); // <- If you want 0's and 1's  
        Sb.Append(a[i] ^ b[i]); // <- Just int, not in binary format as in your solution
            
      return Sb.ToString();
    }
    public static String CharToBinary(int value, Boolean useUnicode = false) {
      int size = useUnicode ? 16 : 8;
      StringBuilder Sb = new StringBuilder(size);
      Sb.Length = size;
      for (int i = size - 1; i >= 0; --i) {
        Sb[i] = value % 2 == 0 ? '0' : '1';
        value /= 2;
      }
      return Sb.ToString();
    }
