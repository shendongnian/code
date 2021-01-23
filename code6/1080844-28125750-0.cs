      public static class LinqExtensions
      {
        public static IEnumerable<TP> FlattenProperties<T, TP>(this IEnumerable<T> outers,
            Func<T, TP> propertySelector, Func<T, IEnumerable<T>> innersSelector)
        {
          Stack<T> stack = new Stack<T>(outers);
          while (stack.Any())
          {
            T outer = stack.Pop();
    
            TP prop = propertySelector(outer);
            yield return prop;
            if (innersSelector(outer) != null)
            {
              foreach (var inner in innersSelector(outer))
                stack.Push(inner);
            }
          }
        }
      }
