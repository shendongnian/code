        public static class IfNotNullExtensionMethod
        {
          public static T2 IfNotNull<T1, T2>(this T1 t, Func<T1, T2> fn)
            where T1: class
          {
            return t != null ? fn(t) : default(T2);
          }
        }
        ...
        public int TempoInteger {
          get {
            double result;
        
            if (TryGetValue(out result, 
              s => s > 0.0d, 
              s => s.TempoBass, 
              s => s.AudioSummary.IfNotNull(x => x.Tempo))) 
            {
              return (int)Math.Round(result);
            }
            return -1;
          }
        }
        ...
