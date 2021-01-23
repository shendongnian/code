    public static void Main(string[] args)
    {
      Dictionary<string, HashSet<string>> data = new Dictionary<string, HashSet<string>>();
      data.Add("k1", "v1.1");
      data.Add("k1", "v1.2");
      data.Add("k1", "v1.1"); // already in, so nothing happens here
      data.Add("k2", "v2.1");
      foreach (var kv in data.KeyValuePairs())
         Console.WriteLine(kv.Key + " : " + kv.Value);
    }
