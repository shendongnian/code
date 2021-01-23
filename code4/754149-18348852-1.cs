    public class MyComparer<T> : IComparer<T> {
       public MyComparer(bool ascending){
          Descending = !ascending;
       }
       public bool Descending {get;set;}
       public int Compare(T x, T y){
          //your normal logic
          int result = ....;
          return Descending ? -result : result;
       }
    }
