        private static Char ConvertToChar(String value) {
          int result = 0;
    
          foreach (Char ch in value)
            result = result * 2 + ch - '0';
    
          return (Char) result;
        }
    
        public string BitsToChar(string value) {
          if (String.IsNullOrEmpty(value))
            return value;
    
          StringBuilder Sb = new StringBuilder();
    
          for (int i = 0; i < value.Length / 8; ++i)
            Sb.Append(ConvertToChar(value.Substring(8 * i, 8)));
    
          return Sb.ToString();
        }
...
       String result = BitsToChar("010000010010000001100010"); // <- "A b"
