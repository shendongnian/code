    public class MyExtraLinqyStuff
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
          //Do null checks immediately;
          if(first == null)
            throw new ArgumentNullException("first");
          if(second == null)
            throw new ArgumentNullException("second");
          if(resultSelector == null)
            throw new ArgumentNullException("resultSelector");
          return DoZip(first, second, resultSelector);
        }
        private static IEnumerable<TResult> DoZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
          using(var enF = first.GetEnumerator())
          using(var enS = second.GetEnumerator())
            while(enF.MoveNext() && enS.MoveNext())
              yield return resultSelector(enF.Current, enS.Current);
        }
    }
