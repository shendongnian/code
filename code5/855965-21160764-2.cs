    // Let Generator be thread safe
    private static ThreadLocal<Random> s_Generator = new ThreadLocal<Random>(
     () => new Random());
    public static Random Generator {
      get {
        return s_Generator.Value;
      }
    }
    // For repetition test. One can remove repetion test if 
    // number of generated ids << 15000
    private HashSet<String> m_UsedIds = new HashSet<String>();
    public string GetNewId() {
      int codeLength = 5;
      string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      while (true) {
        StringBuilder builder = new StringBuilder(codeLength);
    
        for (int i = 0; i < codeLength; ++i)
          builder.Append(chars[Generator.Next(chars.Length)]); // <- same generator for all calls
    
        result = string.Format("{0}{1}", "T", builder.ToString()); 
    
        // Test if random string in fact a repetition
        if (m_UsedIds.Contains(result))
          continue;
        m_UsedIds.Add(result);
        return result;
      }
    }
