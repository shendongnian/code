    public static class ZipLinqExtension {
      public static IEnumerable<TResult> Zip<T1,T2,TResult>(this IEnumerable<T1> source1, 
                                                                 IEnumerable<T2> source2,
                                                                 Func<T1,T2,TResult> function) {
         using (var e1 = source1.GetEnumerator()) {
            using (var e2 = source2.GetEnumerator()) {
               while (e1.MoveNext() && e2.MoveNext()) {
                  yield return function(e1.Current, e2.Current);
               }
            }
         }
      }
   }
   
