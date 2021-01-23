    public string calcXor(String a, String b) {
      int len = (a.Length < b.Length) ? a.Length : b.Length;
    
      StringBuilder Sb = new StringBuilder();
    
      for (int i = 0; i < len; ++i) 
        Sb.Append(a[i] ^ b[i]); // <- Just int, not in binary format
    
      return Sb.ToString();
    }
