    // Let Generator be thread safe
    private static ThreadLocal<Random> s_Generator = new ThreadLocal<Random>(
     () => new Random());
    
    public static Random Generator {
      get {
        return s_Generator.Value;
      }
    }
    public string GetNewId() {
      int codeLength = 5;
      string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      StringBuilder builder = new StringBuilder(codeLength);
    
      for (int i = 0; i < codeLength; ++i)
        builder.Append(chars[Generator.Next(chars.Length)]); // <- same generator for all calls
    
      result = string.Format("{0}{1}", "T", builder.ToString()); 
    
      return result;
    }
