    public static class EnumerableEx {
      public static TObject MinBy<TObj, TProp>(
                                IEnumerable<TObject> input,
                                Func<TObject, TProp> selector) {
        if (!input.MoveNext()) { return default(TObject); }
        TObject obj = input.Current;
        TProp theProp = selector(obj);
        while (input.MoveNext()) {
          var newObj = input.Current;
          var newProp = selector(newObj):
          if (newProp < theProp) {
            obj = newObj;
            theProp = newProp;
          }
        }
        return obj;
    }
