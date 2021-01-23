    public static class Watch<T> where T : class {
      static IList<object> s_References = new List<object>();
      
      public static T Observe<T>(object referrer, T instance) {
        if (!s_References.Contains(referrer)) {
          s_References.Add(referrer);
        }
        return instance;
      }
      public static IList<object> References {
        get { return new ReadOnlyCollection<object>(s_References); }
      }
    }
    AAA aaa = new AAA();
    aaa.fieldInstance = Watch<BBB>.Observe(aaa, new BBB());
    AAA ccc = new AAA();
    ccc.fieldInstance = Watch<BBB>.Observe(ccc, new BBB());
    var foo = Watch<BBB>.References;
    
