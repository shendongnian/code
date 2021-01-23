    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace MyExtensions
    {
      public static class EnumerableExtensions
      {
    
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
        {
          if (source == null)
            throw new ArgumentNullException("source");
          // Ensure that the source IEnumerable is evaluated only once
          return permutations(source.ToArray());
        }
        private static IEnumerable<IEnumerable<T>> permutations<T>(IEnumerable<T> source)
        {
          var c = source.Count();
          if (c == 1)
            yield return source;
          else
            for (int i = 0; i < c; i++)
                foreach (var p in permutations(source.Take(i).Concat(source.Skip(i + 1))))
                    yield return source.Skip(i).Take(1).Concat(p);
        }
      }
    }
