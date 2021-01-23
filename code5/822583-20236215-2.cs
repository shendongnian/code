    public static class EnumerableExtension {
       public static IEnumerable<T> Cast<T>(this System.Collections.IEnumerable source){
         foreach(var item in source)
            yield return (T)item;
       }
    }
