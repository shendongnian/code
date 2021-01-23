    public static class MagicalHelpper
    {
    private static ConditionalWeakTable<object, int> _registry = new ConditionalWeakTable<object, int>();
    
    public void GetId(object obj)
    {
     int result = _registry.GetValue(obj, ((object key)=> DateTime.Now.Ticks +   
                                                      Thread.CurrentThread.ManagedThreadId));
      return result;
    
    }
    }
